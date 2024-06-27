namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendAzurePipelineEventEventsCommandHandler(IPublishEndpoint publishEndpoint)
: IRequestHandler<AzureWebhookModelEvent<PipeLinesResource>>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(
        AzureWebhookModelEvent<PipeLinesResource> request,
        CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
    }
}