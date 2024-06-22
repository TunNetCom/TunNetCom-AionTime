using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record ResourceContainers(
    [property: JsonProperty(PropertyName = "collection", NullValueHandling = NullValueHandling.Ignore)]
    Collection? Collection,

    [property: JsonProperty(PropertyName = "account", NullValueHandling = NullValueHandling.Ignore)]
    Account? Account,

    [property: JsonProperty(PropertyName = "project", NullValueHandling = NullValueHandling.Ignore)]
    Project? Project);