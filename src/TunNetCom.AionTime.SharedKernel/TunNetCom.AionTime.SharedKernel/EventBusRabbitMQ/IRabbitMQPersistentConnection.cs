using TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ;

namespace TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ;

public interface IRabbitMQPersistentConnection
    : IDisposable
{
    bool IsConnected { get; }

    bool TryConnect();

    IModel CreateModel();
}