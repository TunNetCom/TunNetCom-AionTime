namespace AzureDevopsService.Contracts.Internal.Interfaces;

public interface IWebhookService
{
    Task<OneOf<WebhookResponce, WebhookBadRequestResponce>> CreateWebhookSubscription(ServiceHookReques request);
}