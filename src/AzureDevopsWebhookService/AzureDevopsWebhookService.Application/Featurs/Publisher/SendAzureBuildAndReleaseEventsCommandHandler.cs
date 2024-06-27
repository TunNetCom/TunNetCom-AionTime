namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendAzureBuildAndReleaseEventsCommandHandler(IPublishEndpoint publishEndpoint)
    : IRequestHandler<AzureWebhookModelEvent<BuildAndReleaseResource>>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(
        AzureWebhookModelEvent<BuildAndReleaseResource> request,
        CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
    }
}