namespace AzureDevopsService.Contracts.ExternalRequestModel;

public class CreateWebhookRequest : BaseRequest
{
    public List<Organization> Organizations { get; set; } = [];
}