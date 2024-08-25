namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Logs(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    int Id,

    [property: JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
    string? Type,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);