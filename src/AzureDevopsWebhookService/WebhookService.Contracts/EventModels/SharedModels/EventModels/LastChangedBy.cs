namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record LastChangedBy(
    [property: JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
    string? DisplayName,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "_links", NullValueHandling = NullValueHandling.Ignore)]
    Links? Links,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    string? UniqueName,

    [property: JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    Uri? ImageUrl,

    [property: JsonProperty(PropertyName = "descriptor", NullValueHandling = NullValueHandling.Ignore)]
    string? Descriptor);