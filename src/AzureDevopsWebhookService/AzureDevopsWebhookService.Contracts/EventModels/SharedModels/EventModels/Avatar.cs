namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Avatar(
    [property: JsonProperty(PropertyName = "href", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Href);