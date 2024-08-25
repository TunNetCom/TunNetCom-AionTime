namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Project(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
    string? State,

    [property: JsonProperty(PropertyName = "revision", NullValueHandling = NullValueHandling.Ignore)]
    int Revision,

    [property: JsonProperty(PropertyName = "visibility", NullValueHandling = NullValueHandling.Ignore)]
    string? Visibility,

    [property: JsonProperty(PropertyName = "lastUpdateTime", NullValueHandling = NullValueHandling.Ignore)]
    string? LastUpdateTime);