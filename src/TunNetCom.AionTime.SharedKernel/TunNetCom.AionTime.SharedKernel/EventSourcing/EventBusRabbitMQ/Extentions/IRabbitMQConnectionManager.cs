namespace TunNetCom.AionTime.SharedKernel.EventSourcing.EventBusRabbitMQ.Extentions;

public interface IRabbitMQConnectionManager : IAsyncDisposable
{
    Task<IChannel> GetChannelAsync();
    Task<bool> TryConnectAsync();
    bool IsConnected { get; }
}
