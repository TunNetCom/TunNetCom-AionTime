namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync<T>(T @integrationEvent) 
        where T : IntegrationEvent;

    void Subscribe<T, TH>()
     where T : IntegrationEvent
     where TH : IIntegrationEventHandler<T>;
}