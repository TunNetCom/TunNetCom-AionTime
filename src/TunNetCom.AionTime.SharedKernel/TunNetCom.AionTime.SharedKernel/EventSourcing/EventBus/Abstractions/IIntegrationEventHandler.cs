public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
where TIntegrationEvent : IntegrationEvent
{
    Task Handle(TIntegrationEvent @integrationEvent);

    Task IIntegrationEventHandler.Handle(IntegrationEvent @integrationEvent)
    {
        return Handle((TIntegrationEvent)@integrationEvent);
    }
}

public interface IIntegrationEventHandler
{
    Task Handle(IntegrationEvent @integrationEvent);
}