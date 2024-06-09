namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Account
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}