namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public record Collection(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id);
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix