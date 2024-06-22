using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Repository(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "project", NullValueHandling = NullValueHandling.Ignore)]
    Project? Project,

    [property: JsonProperty(PropertyName = "defaultBranch", NullValueHandling = NullValueHandling.Ignore)]
    string? DefaultBranch,

    [property: JsonProperty(PropertyName = "remoteUrl", NullValueHandling = NullValueHandling.Ignore)]
    Uri? RemoteUrl);