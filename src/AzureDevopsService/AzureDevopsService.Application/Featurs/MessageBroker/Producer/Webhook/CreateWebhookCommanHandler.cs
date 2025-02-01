namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.Webhook;

public class CreateWebhookCommanHandler(IWebhookService webhookService , IPublishEndpoint publishEndpoint) : IRequestHandler<CreateWebhookCommand, WebhookCreatedResponse>
{
    private readonly IWebhookService _webhookService = webhookService;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task<WebhookCreatedResponse> Handle(CreateWebhookCommand request, CancellationToken cancellationToken)
    {
        List<ServiceHookReques> allRequest = EventCreationHelper.PrepareAllWbhookEventRequest(request.Request);
        WebhookCreatedResponse CreatedWebhook = new() { Email = request.Request.Email,Path = request.Request.Path};
        foreach (ServiceHookReques serviecHookRequestMessage in allRequest)
        {
            OneOf<WebhookResponce, WebhookBadRequestResponce> webhookResponse = await _webhookService.CreateWebhookSubscription(serviecHookRequestMessage);

            if (webhookResponse.IsT0)
            {
                CreatedWebhook.SubscriptionList.Add(webhookResponse.AsT0);
            }
        }

        await _publishEndpoint.Publish(CreatedWebhook, cancellationToken);

        return CreatedWebhook;
    }
}