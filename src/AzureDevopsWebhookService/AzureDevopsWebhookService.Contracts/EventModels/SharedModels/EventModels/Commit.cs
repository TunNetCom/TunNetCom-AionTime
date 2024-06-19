using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class Commit : BaseCommit
{
    [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
    public Author? Author { get; set; }

    [JsonProperty("committer", NullValueHandling = NullValueHandling.Ignore)]
    public Committer? Committer { get; set; }

    [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
    public string? Comment { get; set; }
}