namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @integrationEvent);
}