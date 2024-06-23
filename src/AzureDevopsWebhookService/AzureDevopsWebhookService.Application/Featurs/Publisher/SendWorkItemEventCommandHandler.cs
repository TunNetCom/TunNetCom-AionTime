namespace AzureDevopsWebhookService.Application.Featurs.Publisher
{
    public class SendWorkItemEventCommandHandler(IPublishEndpoint publishEndpoint)
    : IRequestHandler<AzureWebhookModelEvent<WorkItemResource>, HttpStatusCode>
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public async Task<HttpStatusCode> Handle(AzureWebhookModelEvent<WorkItemResource> request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish(request, cancellationToken);
            return HttpStatusCode.OK;
        }
    }
}