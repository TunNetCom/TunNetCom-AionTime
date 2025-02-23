namespace AzureDevopsService.Contracts.SharedModel;

public class PublisherInputsWebhookResponce
{
    [JsonProperty("tfsSubscriptionId")]
    public string TfsSubscriptionId { get; set; }
}