namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.ResourcesModels;

public record WorkItemResource(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    int? Id,

    [property: JsonProperty(PropertyName = "rev", NullValueHandling = NullValueHandling.Ignore)]
    int? Rev,

    [property: JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
    Fileds? Fileds,

    [property: JsonProperty(PropertyName = "_links", NullValueHandling = NullValueHandling.Ignore)]
    Link? Links,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);