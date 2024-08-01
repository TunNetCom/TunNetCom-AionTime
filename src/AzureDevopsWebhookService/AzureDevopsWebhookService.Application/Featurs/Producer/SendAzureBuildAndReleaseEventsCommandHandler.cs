using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels;
using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.ResourcesModels;

namespace TunNetCom.AionTime.AzureDevops.WebhookService.Application.Featurs.Producer;

public class SendAzureBuildAndReleaseEventsCommandHandler(ISendEndpointProvider sendEndpointProvider)
    : IRequestHandler<AzureWebhookModelEvent<BuildAndReleaseResource>>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(
        AzureWebhookModelEvent<BuildAndReleaseResource> request,
        CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/BuildAndReleaseEvents"));
        await endpoint.Send(request, cancellationToken);
    }
}