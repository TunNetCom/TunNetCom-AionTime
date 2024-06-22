using AzureDevopsWebhookService;
namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record BaseCommit(
    [property: JsonProperty(PropertyName = "commitId", NullValueHandling = NullValueHandling.Ignore)]
    string? CommitId,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);