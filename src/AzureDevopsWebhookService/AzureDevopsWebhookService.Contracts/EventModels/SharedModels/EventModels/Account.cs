namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Account(
    [property: JsonProperty(PropertyName = "resource", NullValueHandling = NullValueHandling.Ignore)]
    string? Id);