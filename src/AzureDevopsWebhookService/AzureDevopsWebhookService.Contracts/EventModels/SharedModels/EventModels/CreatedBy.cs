namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record CreatedBy(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
    string? DisplayName,

    [property: JsonProperty(PropertyName = "uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    string? UniqueName,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    Uri? ImageUrl);