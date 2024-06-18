using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Commit
{
    [JsonProperty("commitId", NullValueHandling = NullValueHandling.Ignore)]
    public string? CommitId { get; set; }

    [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
    public Author? Author { get; set; }

    [JsonProperty("committer", NullValueHandling = NullValueHandling.Ignore)]
    public Committer? Committer { get; set; }

    [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
    public string? Comment { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }
}