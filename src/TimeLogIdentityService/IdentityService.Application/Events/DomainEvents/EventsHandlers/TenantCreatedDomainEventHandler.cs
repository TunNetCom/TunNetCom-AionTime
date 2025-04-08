using IdentityService.Application.Events.DomainEvents.Events;
using IdentityService.Application.Events.IntegrationEvents.Events.Outgoing;

namespace IdentityService.Application.Events.DomainEvents.EventsHandlers;

public class TenantCreatedDomainEventHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<TenantCreatedDomainEvent>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(TenantCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));
        TenantCreatedIntegrationEvent retriveUserOrganizationIntegrationEvent = new(notification.UserEmail, notification.AzureDevOpsPath, notification.TenantId);

        await endpoint.Send(retriveUserOrganizationIntegrationEvent, ctx =>
            {
                ctx.Headers.Set(MessageQueueHeader.TenantId, notification.TenantId.ToString());
                ctx.Headers.Set(MessageQueueHeader.UserEmail, notification.UserEmail);
            }, cancellationToken);
    }
}