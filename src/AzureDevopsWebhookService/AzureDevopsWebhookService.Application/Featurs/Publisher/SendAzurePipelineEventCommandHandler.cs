using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels;
using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.ResourcesModels;

namespace TunNetCom.AionTime.AzureDevops.WebhookService.Application.Featurs.Publisher;

public class SendAzurePipelineEventCommandHandler(ISendEndpointProvider sendEndpointProvider)
: IRequestHandler<AzureWebhookModelEvent<PipeLinesResource>>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(
        AzureWebhookModelEvent<PipeLinesResource> request,
        CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/PipelineEvent"));
        await endpoint.Send(request, cancellationToken);
    }
}