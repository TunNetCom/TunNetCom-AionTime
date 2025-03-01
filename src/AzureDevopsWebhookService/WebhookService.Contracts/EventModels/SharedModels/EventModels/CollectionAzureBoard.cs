namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record CollectionAzureBoard(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id);