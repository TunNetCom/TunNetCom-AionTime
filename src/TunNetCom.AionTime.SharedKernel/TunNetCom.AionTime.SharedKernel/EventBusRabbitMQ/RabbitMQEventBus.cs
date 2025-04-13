namespace TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus, IDisposable
{
    private readonly RabbitMQOptions _config;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RabbitMQEventBus> _logger;
    private readonly IConnectionFactory _connectionFactory;
    private IConnection? _connection;
    private IChannel? _channel;

    private bool _disposed;

    public RabbitMQEventBus(RabbitMQOptions config,
        IServiceProvider serviceProvider,
        ILogger<RabbitMQEventBus> logger)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _connectionFactory = new ConnectionFactory
        {
            HostName = _config.EventBusConnection,
            UserName = _config.EventBusUserName,
            Password = _config.EventBusPassword,
        };

        _connection =  _connectionFactory.CreateConnectionAsync().GetAwaiter().GetResult();
        _channel =  _connection.CreateChannelAsync().GetAwaiter().GetResult();
        this.TryConnect().GetAwaiter().GetResult();
        
    }

    private async Task TryConnect()
    {
        const int maxRetries = 3;
        for (int attempt = 0; attempt < maxRetries; attempt++)
        {

            try
            {
             
                await _channel.ExchangeDeclareAsync(exchange: _config.BrokerName, type: ExchangeType.Fanout, durable: true);
                _logger.LogInformation("Connected to RabbitMQ.");
                return;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Attempt {Attempt} failed to connect to RabbitMQ. Retrying...", attempt + 1);
                if (attempt == maxRetries - 1)
                {
                    _logger.LogError(ex, "Failed to connect to RabbitMQ after {MaxRetries} attempts.", maxRetries);
                    throw;
                }
                Thread.Sleep(1000 * (attempt + 1)); 
            }
        }
    }

    public async Task PublishAsync<T>(T @event) where T : IntegrationEvent
    {
        if (_channel == null)
        {
            _logger.LogError("RabbitMQ channel is not initialized.");
            throw new InvalidOperationException("RabbitMQ channel is not initialized.");
        }

        var eventName = typeof(T).Name;
        var message = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(message);

        for (int attempt = 0; attempt <= _config.EventBusRetryCount; attempt++)
        {
            try
            {

                await Task.Run(() =>
                {

                    _channel.BasicPublishAsync(
                        exchange: _config.BrokerName,
                        routingKey: eventName,
                        mandatory: true,
                        body: body);
                });


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

    public void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>
    {
        if (_channel == null)
        {
            _logger.LogError("RabbitMQ channel is not initialized.");
            throw new InvalidOperationException("RabbitMQ channel is not initialized.");
        }

        var eventName = typeof(T).Name;
        var queueName = $"{_config.BrokerName}.{eventName}";

        _channel.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        _channel.QueueBindAsync(queue: queueName, exchange: _config.BrokerName, routingKey: eventName);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            try
            {
                var @event = JsonSerializer.Deserialize<T>(message);
                if (@event != null)
                {
                    using var scope = _serviceProvider.CreateScope();
                    var handler = scope.ServiceProvider.GetRequiredService<TH>();
                    handler.Handle(@event);
                    _logger.LogInformation("Processed event {EventName} with ID {EventId}.", eventName, @event.Id);
                    return Task.CompletedTask;
                }
                else
                {
                    _logger.LogWarning("Failed to deserialize event {EventName}.", eventName);
                    return Task.CompletedTask;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing event {EventName}.", eventName);
                return Task.CompletedTask;

            }
            finally
            {
                _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            }
        };

        _channel.BasicConsumeAsync(queue: queueName, autoAck: false, consumer: consumer);
        _logger.LogInformation("Subscribed to event {EventName} with handler {HandlerName}.", eventName, typeof(TH).Name);
    }

    public void Dispose()
    {
        if (_disposed) return;

        try
        {
            _channel?.CloseAsync();
            _channel?.Dispose();
            _connection?.CloseAsync();
            _connection?.Dispose();
            _disposed = true;
            _logger.LogInformation("RabbitMQ connection disposed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disposing RabbitMQ connection.");
        }
    }
}