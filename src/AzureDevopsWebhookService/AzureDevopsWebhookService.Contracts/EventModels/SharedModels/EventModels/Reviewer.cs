namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Reviewer(
    [property: JsonProperty(PropertyName = "reviewerUrl", NullValueHandling = NullValueHandling.Ignore)]
    Uri? ReviewerUrl,

    [property: JsonProperty(PropertyName = "vote", NullValueHandling = NullValueHandling.Ignore)]
    int Vote,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
    string? DisplayName,

    [property: JsonProperty(PropertyName = "uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    string? UniqueName,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    Uri? ImageUrl,

    [property: JsonProperty(PropertyName = "isContainer", NullValueHandling = NullValueHandling.Ignore)]
    bool IsContainer);