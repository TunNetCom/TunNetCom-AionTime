using MassTransit;

namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

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