namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Author([property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)] string? Name,
    [property: JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
    string? Email,

    [property: JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
    DateTime Date);