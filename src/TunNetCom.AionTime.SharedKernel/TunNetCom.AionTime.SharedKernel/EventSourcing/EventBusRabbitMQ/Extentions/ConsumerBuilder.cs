namespace TunNetCom.AionTime.SharedKernel.EventSourcing.EventBusRabbitMQ.Extensions;

public class ConsumerBuilder
{
    private readonly IServiceCollection _services;

    public ConsumerBuilder(IServiceCollection services)
    {
        _services = services ?? throw new ArgumentNullException(nameof(services));
    }

    public ConsumerBuilder Add<TEvent, THandler>()
        where TEvent : IntegrationEvent
        where THandler : class, IIntegrationEventHandler<TEvent>
    {
        _services.AddConsumer<TEvent, THandler>();
        return this;
    }
}