using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Commit
{
    [JsonProperty("commitId")]
    public string? CommitId { get; set; }

    [JsonProperty("author")]
    public Author? Author { get; set; }

    [JsonProperty("committer")]
    public Committer? Committer { get; set; }

    [JsonProperty("comment")]
    public string? Comment { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings
}