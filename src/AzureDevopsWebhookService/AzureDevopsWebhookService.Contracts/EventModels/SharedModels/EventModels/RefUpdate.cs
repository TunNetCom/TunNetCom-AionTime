using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record RefUpdate(
    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "oldObjectId", NullValueHandling = NullValueHandling.Ignore)]
    string? OldObjectId,

    [property: JsonProperty(PropertyName = "newObjectId", NullValueHandling = NullValueHandling.Ignore)]
    string? NewObjectId);