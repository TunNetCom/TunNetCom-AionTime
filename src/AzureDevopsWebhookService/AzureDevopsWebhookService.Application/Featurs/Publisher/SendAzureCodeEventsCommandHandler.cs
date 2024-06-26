namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendAzureCodeEventsCommandHandler(IPublishEndpoint publishEndpoint)
: IRequestHandler<AzureWebhookModelEvent<CodeResource>,
    AzureWebhookModelEvent<CodeResource>>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<AzureWebhookModelEvent<CodeResource>> Handle(
        AzureWebhookModelEvent<CodeResource> request,
        CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
        return request;
    }
}