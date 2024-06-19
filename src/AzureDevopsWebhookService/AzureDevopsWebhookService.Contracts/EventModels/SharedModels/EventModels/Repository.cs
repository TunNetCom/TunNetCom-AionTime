using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class Repository
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
    public Project? Project { get; set; }

    [JsonProperty("defaultBranch", NullValueHandling = NullValueHandling.Ignore)]
    public string? DefaultBranch { get; set; }

    [JsonProperty("remoteUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string? RemoteUrl { get; set; }
}