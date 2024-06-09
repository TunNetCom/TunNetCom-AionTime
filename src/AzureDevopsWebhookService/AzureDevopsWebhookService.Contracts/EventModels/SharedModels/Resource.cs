using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Resource
{
    [JsonProperty("repository")]
    public Repository? Repository { get; set; }

    [JsonProperty("pullRequestId")]
    public int PullRequestId { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("createdBy")]
    public CreatedBy? CreatedBy { get; set; }

    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonProperty("closedDate")]
    public DateTime ClosedDate { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("sourceRefName")]
    public string? SourceRefName { get; set; }

    [JsonProperty("targetRefName")]
    public string? TargetRefName { get; set; }

    [JsonProperty("mergeStatus")]
    public string? MergeStatus { get; set; }

    [JsonProperty("mergeId")]
    public string? MergeId { get; set; }

    [JsonProperty("lastMergeSourceCommit")]
    public Commit? LastMergeSourceCommit { get; set; }

    [JsonProperty("lastMergeTargetCommit")]
    public Commit? LastMergeTargetCommit { get; set; }

    [JsonProperty("lastMergeCommit")]
    public Commit? LastMergeCommit { get; set; }

    [JsonProperty("reviewers")]
#pragma warning disable CA2227 // Collection properties should be read only
#pragma warning disable CA1002 // Do not expose generic lists
    public List<Reviewer>? Reviewers { get; set; }
#pragma warning restore CA1002 // Do not expose generic lists
#pragma warning restore CA2227 // Collection properties should be read only

    [JsonProperty("commits")]
#pragma warning disable CA2227 // Collection properties should be read only
#pragma warning disable CA1002 // Do not expose generic lists
    public List<Commit>? Commits { get; set; }
#pragma warning restore CA1002 // Do not expose generic lists
#pragma warning restore CA2227 // Collection properties should be read only

    [JsonProperty("refUpdates")]
#pragma warning disable CA1002 // Do not expose generic lists
#pragma warning disable CA2227 // Collection properties should be read only
    public List<RefUpdate>? RefUpdates { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning restore CA1002 // Do not expose generic lists

    [JsonProperty("pushedBy")]
    public PushedBy? PushedBy { get; set; }

    [JsonProperty("pushId")]
    public int? PushId { get; set; }

    [JsonProperty("date")]
    public DateTime? Date { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("queueTime")]
    public DateTime? QueueTime { get; set; }

    [JsonProperty("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonProperty("finishTime")]
    public DateTime? FinishTime { get; set; }

    [JsonProperty("definition")]
    public Definition? Definition { get; set; }

    [JsonProperty("buildNumberRevision")]
    public int? BuildNumberRevision { get; set; }

    [JsonProperty("requestedFor")]
    public RequestedFor? RequestedFor { get; set; }

    [JsonProperty("requestedBy")]
    public RequestedBy? RequestedBy { get; set; }

    [JsonProperty("lastChangedBy")]
    public LastChangedBy? LastChangedBy { get; set; }

    [JsonProperty("logs")]
    public Logs? Logs { get; set; }
}