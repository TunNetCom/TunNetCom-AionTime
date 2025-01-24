namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.HooksService;

public interface IWebhookService
{
    Task<OneOf<WebhookResponce, WebhookBadRequestResponce>> CreateWebhookSubscription(ServiceHookRequest request);
}