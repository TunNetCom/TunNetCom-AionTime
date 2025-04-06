namespace AzureDevopsService.Contracts.SharedModel;

public class PublisherInputsWebhookResponce
{
    [JsonProperty("tfsSubscriptionId")]
    public required string TfsSubscriptionId { get; set; }
}