using IdentityService.Application.Events.DomainEvents.Events;
using IdentityService.Application.Events.IntegrationEvents.Events.Outgoing;
using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

namespace IdentityService.Application.Events.DomainEvents.EventsHandlers;

public class TenantCreatedDomainEventHandler(IEventBus eventBus) : INotificationHandler<TenantCreatedDomainEvent>
{

    public async Task Handle(TenantCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        TenantCreatedIntegrationEvent retriveUserOrganizationIntegrationEvent = new(notification.UserEmail, notification.AzureDevOpsPath, notification.TenantId);

        await eventBus.PublishAsync(retriveUserOrganizationIntegrationEvent);

    }
}