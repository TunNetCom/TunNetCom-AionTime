 namespace TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus, IDisposable
{
    private readonly IRabbitMQConnectionManager _connectionManager;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RabbitMQEventBus> _logger;
    private readonly RabbitMQOptions _config;
    private bool _disposed;

    public RabbitMQEventBus(
        IRabbitMQConnectionManager connectionManager,
        IServiceProvider serviceProvider,
        ILogger<RabbitMQEventBus> logger,
        RabbitMQOptions config)
    {
        _connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public async Task PublishAsync<T>(T @event) where T : IntegrationEvent
    {
        if (!_connectionManager.IsConnected)
        {
            await _connectionManager.TryConnectAsync();
        }

        var channel = await _connectionManager.GetChannelAsync();
        var eventName = typeof(T).Name;
        var message = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(message);

        for (int attempt = 0; attempt <= _config.EventBusRetryCount; attempt++)
        {
            try
            {
                await channel.BasicPublishAsync(
                    exchange: _config.BrokerName,
                    routingKey: eventName,
                    mandatory: true,
                    body: body);

                _logger.LogInformation("Published event {EventName} with ID {EventId}.", eventName, @event.Id);
                return;
            }
            catch (BrokerUnreachableException ex)
            {
                _logger.LogWarning(ex, "Attempt {Attempt} failed to publish event {EventName}. Retrying...", attempt + 1, eventName);
                if (attempt == _config.EventBusRetryCount)
                {
                    _logger.LogError(ex, "Failed to publish event {EventName} after {RetryCount} attempts.", eventName, _config.EventBusRetryCount);
                    throw;
                }

                await Task.Delay(1000 * (attempt + 1));
            }
        }
    }

    public async void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        if (!_connectionManager.IsConnected)
        {
            await _connectionManager.TryConnectAsync();
        }

        var channel = await _connectionManager.GetChannelAsync();
        var eventName = typeof(T).Name;
        var queueName = $"{_config.BrokerName}.{eventName}";

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false);

        await channel.QueueBindAsync(
            queue: queueName,
            exchange: _config.BrokerName,
            routingKey: eventName);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            try
            {
                var @event = JsonSerializer.Deserialize<T>(message);
                if (@event == null)
                {
                    _logger.LogWarning("Failed to deserialize event {EventName}.", eventName);
                    return;
                }

                using var scope = _serviceProvider.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<TH>();

                await handler.Handle(@event);

                await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                _logger.LogInformation("Processed event {EventName} with ID {EventId}.", eventName, @event.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing event {EventName}.", eventName);

                // TODO: Handle the error (imlimentation of dead-letter mechanism)
            }
        };

        await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: false,
            consumer: consumer);

        _logger.LogInformation("Subscribed to event {EventName} with handler {HandlerName}.", eventName, typeof(TH).Name);
    }

    public void Dispose()
    {
        if (_disposed) return;

        _connectionManager.DisposeAsync();
        _disposed = true;
    }
}
