namespace AzureDevopsWebhookService.Application.Featurs.Publisher;

public class SendWorkItemEventCommandHandler(IPublishEndpoint publishEndpoint)
: IRequestHandler<AzureWebhookModelEvent<WorkItemResource>>
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(
        AzureWebhookModelEvent<WorkItemResource> request,
        CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(request, cancellationToken);
    }
}