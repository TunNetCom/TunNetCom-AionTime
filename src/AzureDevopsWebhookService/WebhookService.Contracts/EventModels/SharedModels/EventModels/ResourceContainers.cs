namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record ResourceContainers(
    [property: JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
    CollectionAzureBoard? Collection,

    [property: JsonProperty(PropertyName = "account", NullValueHandling = NullValueHandling.Ignore)]
    Account? Account,

    [property: JsonProperty(PropertyName = "project", NullValueHandling = NullValueHandling.Ignore)]
    Project? Project);