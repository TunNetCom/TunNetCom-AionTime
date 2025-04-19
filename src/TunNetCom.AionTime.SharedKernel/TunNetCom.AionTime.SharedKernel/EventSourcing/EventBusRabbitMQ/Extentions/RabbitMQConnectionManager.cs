namespace TunNetCom.AionTime.SharedKernel.EventSourcing.EventBusRabbitMQ.Extensions;

public class RabbitMQConnectionManager : IRabbitMQConnectionManager
{
    private readonly RabbitMQOptions _config;
    private readonly ILogger<RabbitMQConnectionManager> _logger;
    private readonly IConnectionFactory _connectionFactory;
    private IConnection? _connection;
    private IChannel? _channel;
    private bool _disposed;
    private readonly object _lock = new();

    public RabbitMQConnectionManager(RabbitMQOptions config, ILogger<RabbitMQConnectionManager> logger)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        if (string.IsNullOrEmpty(_config.EventBusConnection))
            throw new ArgumentException("EventBusConnection must be specified.", nameof(config));
        if (string.IsNullOrEmpty(_config.BrokerName))
            throw new ArgumentException("BrokerName must be specified.", nameof(config));

        _connectionFactory = new ConnectionFactory
        {
            HostName = _config.EventBusConnection,
            UserName = _config.EventBusUserName,
            Password = _config.EventBusPassword,
            AutomaticRecoveryEnabled = true,
            RequestedHeartbeat = TimeSpan.FromSeconds(60)
        };
    }

    public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;

    public async Task<IChannel> GetChannelAsync()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(RabbitMQConnectionManager));

        if (_channel != null && !_channel.IsClosed)
            return _channel;

        if (_connection == null || !_connection.IsOpen)
            _connection = await _connectionFactory.CreateConnectionAsync();

        _channel = await _connection.CreateChannelAsync();
        await _channel.ExchangeDeclareAsync(_config.BrokerName, _config.ExchangeType, durable: true);

        _logger.LogInformation("RabbitMQ channel created and exchange {BrokerName} declared with type {ExchangeType}.", _config.BrokerName, _config.ExchangeType);

        return _channel;
    }

    public async Task<bool> TryConnectAsync()
    {
        try
        {
            var policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    _config.EventBusRetryCount,
                    attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                    (ex, time, attempt, ctx) =>
                        _logger.LogWarning(ex, "Attempt {Attempt} failed to connect to RabbitMQ. Retrying in {Time}.", attempt, time));

            await policy.ExecuteAsync(async () =>
            {
                var channel = await GetChannelAsync();
                _logger.LogInformation("Connected to RabbitMQ with broker {BrokerName}.", _config.BrokerName);
            });
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while trying to connect to RabbitMQ.");
            return false;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        try
        {
            if (_channel != null)
            {
                await _channel.CloseAsync();
                _channel.Dispose();
                _channel = null;
            }

            if (_connection != null)
            {
                await _connection.CloseAsync();
                _connection.Dispose();
                _connection = null;
            }

            _disposed = true;
            _logger.LogInformation("RabbitMQ connection disposed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disposing RabbitMQ connection.");
        }
    }
}