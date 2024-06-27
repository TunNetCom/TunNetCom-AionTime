namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Url(
    [property: JsonProperty(PropertyName = "href", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Href);