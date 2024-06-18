namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Account
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }
}