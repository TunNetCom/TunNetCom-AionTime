using IdentityService.Application.Events.DomainEvents.Events;
using IdentityService.Application.Events.IntegrationEvents.Events.Outgoing;
using IdentityService.Domain.Models.Dbo;
using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

namespace IdentityService.Application.Events.DomainEvents.EventsHandlers;

public class TenantCreatedDomainEventHandler(IEventBus eventBus) : INotificationHandler<TenantCreatedDomainEvent>
{

    public async Task Handle(TenantCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        TenantCreatedIntegrationEvent retriveUserOrganizationIntegrationEvent = new(
            Email:notification.UserEmail,
            TenantId:notification.TenantId,
            Pat: notification.AzureDevOpsPath,
            OrganizationName:notification.OrganizationName);

        await eventBus.PublishAsync(retriveUserOrganizationIntegrationEvent);

    }
}