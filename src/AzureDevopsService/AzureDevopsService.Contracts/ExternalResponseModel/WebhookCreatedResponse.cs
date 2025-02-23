namespace AzureDevopsService.Contracts.ExternalResponseModel;

public class WebhookCreatedResponse : BaseRequest
{
    public List<WebhookResponce> SubscriptionList { get; set; } = [];
}