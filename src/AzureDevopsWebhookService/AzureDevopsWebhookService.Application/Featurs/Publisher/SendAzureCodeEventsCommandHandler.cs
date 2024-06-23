namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendAzureCodeEventsCommandHandler(IPublishEndpoint publishEndpoint)
: IRequestHandler<AzureWebhookModelEvent<CodeResource>, HttpStatusCode>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<HttpStatusCode> Handle(AzureWebhookModelEvent<CodeResource> request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
        return HttpStatusCode.OK;
    }
}