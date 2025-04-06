// using AzureDevopsService.Application.Featurs.CreateProjectsServicehooks;

// namespace AzureDevopsService.Application.Featurs.CreateProjectsServicehooks;

// public class CreateProjectsServicehooksCommanHandler(
//    IWebhookService webhookService,
//    IPublishEndpoint publishEndpoint) : IRequestHandler<CreateProjectsServicehooksCommand, WebhookCreatedIntegrationEvent>
// {
//    private readonly IWebhookService _webhookService = webhookService;
//    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

// public async Task<WebhookCreatedIntegrationEvent> Handle(CreateProjectsServicehooksCommand request, CancellationToken cancellationToken)
//    {
//        List<ServiceHookReques> allRequest = EventCreationHelper.PrepareAllWbhookEventRequest(request);

// List<WebhookResponce> subscriptionList = [];

// foreach (ServiceHookReques serviecHookRequestMessage in allRequest)
//        {
//            OneOf<WebhookResponce, WebhookBadRequestResponce> webhookResponse = await _webhookService.CreateWebhookSubscription(serviecHookRequestMessage);

// if (webhookResponse.IsT0)
//            {
//                subscriptionList.Add(webhookResponse.AsT0);
//            }
//        }

// WebhookCreatedIntegrationEvent createdWebhook = new(
//            request.Email,
//            request.Path,
//            request.TenantId,
//            subscriptionList.AsReadOnly());

// await _publishEndpoint.Publish(createdWebhook, cancellationToken);

// return createdWebhook;
//    }
// }