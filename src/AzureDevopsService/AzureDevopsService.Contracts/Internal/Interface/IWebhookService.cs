namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IWebhookService
{
    Task<OneOf<WebhookResponce, WebhookBadRequestResponce>> CreateWebhookSubscription(ServiceHookReques request);
}