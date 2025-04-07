using static TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ.Extensions.InMemoryEventBusSubscriptionsManager;

namespace TunNetCom.AionTime.SharedKernel.EventBusRabbitMQ.Extensions;

public interface IEventBusSubscriptionsManager
{
    event EventHandler<EventRemovedEventArgs> OnEventRemoved;

    event EventHandler<string> OnEventRemoved;

    bool IsEmpty { get; }

    void AddDynamicSubscription<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;

    void AddSubscription<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>;

    void RemoveSubscription<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;

    void RemoveDynamicSubscription<TH>(string eventName)
        where TH : IDynamicIntegrationEventHandler;

    bool HasSubscriptionsForEvent<T>()
        where T : IntegrationEvent;

    bool HasSubscriptionsForEvent(string eventName);

    Type GetEventTypeByName(string eventName);

    void Clear();

    IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>()
        where T : IntegrationEvent;

    IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

    string GetEventKey<T>();
}

public class EventRemovedEventArgs(string eventName) : EventArgs
{
    public string EventName { get; } = eventName;
}