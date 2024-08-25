namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Links(
    [property: JsonProperty(PropertyName = "avatar", NullValueHandling = NullValueHandling.Ignore)]
    Url? Avatar);