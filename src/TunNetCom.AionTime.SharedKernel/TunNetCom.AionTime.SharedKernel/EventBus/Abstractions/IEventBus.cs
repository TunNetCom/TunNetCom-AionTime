namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @integrationEvent);

    void Subscribe<T, TH>()
     where T : IntegrationEvent
     where TH : IIntegrationEventHandler<T>;

    void SubscribeDynamic<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;

    void UnsubscribeDynamic<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;

    void Unsubscribe<T, TH>()
        where TH : IIntegrationEventHandler<T>
        where T : IntegrationEvent;
}