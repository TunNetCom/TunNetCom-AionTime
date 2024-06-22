using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record BaseCommit(
    [property: JsonProperty(PropertyName = "commitId", NullValueHandling = NullValueHandling.Ignore)]
    string? CommitId,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);