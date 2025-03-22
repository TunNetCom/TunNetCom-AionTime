using IdentityService.Application.Features.InternalTreatement.Events.TenatCreated;
using IdentityService.Contracts.Constant;

namespace IdentityService.Application.Features.MessageBroker.Producer;

public class ProfileAzureUserCommandHandler(ISendEndpointProvider sendEndpointProvider) : INotificationHandler<TenantCreatedNotification>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(TenantCreatedNotification request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));

        GetAzureAdminInfoRequest azureRequest = new()
        {
            TenantId = request.TenantId.ToString(),
            Email = request.UserEmail,
            Path = request.AzureDevOpsPath,
        };

        await endpoint.Send(azureRequest, ctx =>
        {
            ctx.Headers.Set(MessageQueueHeader.TenantId, request.TenantId.ToString());
            ctx.Headers.Set(MessageQueueHeader.UserEmail, request.UserEmail);
        }, cancellationToken);
    }
}