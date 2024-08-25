namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Resource(
    [property: JsonProperty(PropertyName = "repository", NullValueHandling = NullValueHandling.Ignore)]
    Repository? Repository,

    [property: JsonProperty(PropertyName = "pullRequestId", NullValueHandling = NullValueHandling.Ignore)]
    int PullRequestId,

    [property: JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
    string? Status,

    [property: JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
    CreatedBy? CreatedBy,

    [property: JsonProperty(PropertyName = "creationDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime CreationDate,

    [property: JsonProperty(PropertyName = "closedDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime ClosedDate,

    [property: JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
    string? Title,

    [property: JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
    string? Description,

    [property: JsonProperty(PropertyName = "sourceRefName", NullValueHandling = NullValueHandling.Ignore)]
    string? SourceRefName,

    [property: JsonProperty(PropertyName = "targetRefName", NullValueHandling = NullValueHandling.Ignore)]
    string? TargetRefName,

    [property: JsonProperty(PropertyName = "mergeStatus", NullValueHandling = NullValueHandling.Ignore)]
    string? MergeStatus,

    [property: JsonProperty(PropertyName = "mergeId", NullValueHandling = NullValueHandling.Ignore)]
    string? MergeId,

    [property: JsonProperty(PropertyName = "lastMergeSourceCommit", NullValueHandling = NullValueHandling.Ignore)]
    Commit? LastMergeSourceCommit,

    [property: JsonProperty(PropertyName = "lastMergeTargetCommit", NullValueHandling = NullValueHandling.Ignore)]
    Commit? LastMergeTargetCommit,

    [property: JsonProperty(PropertyName = "lastMergeCommit", NullValueHandling = NullValueHandling.Ignore)]
    Commit? LastMergeCommit,

    [property: JsonProperty(PropertyName = "reviewers", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<Reviewer>? Reviewers,

    [property: JsonProperty(PropertyName = "commits", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<Commit>? Commits,

    [property: JsonProperty(PropertyName = "refUpdates", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<RefUpdate>? RefUpdates,

    [property: JsonProperty(PropertyName = "pushedBy", NullValueHandling = NullValueHandling.Ignore)]
    PushedBy? PushedBy,

    [property: JsonProperty(PropertyName = "pushId", NullValueHandling = NullValueHandling.Ignore)]
    int? PushId,

    [property: JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? Date,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "queueTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? QueueTime,

    [property: JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? StartTime,

    [property: JsonProperty(PropertyName = "finishTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? FinishTime,

    [property: JsonProperty(PropertyName = "definition", NullValueHandling = NullValueHandling.Ignore)]
    Definition? Definition,

    [property: JsonProperty(PropertyName = "buildNumberRevision", NullValueHandling = NullValueHandling.Ignore)]
    int? BuildNumberRevision,

    [property: JsonProperty(PropertyName = "requestedFor", NullValueHandling = NullValueHandling.Ignore)]
    RequestedFor? RequestedFor,

    [property: JsonProperty(PropertyName = "requestedBy", NullValueHandling = NullValueHandling.Ignore)]
    RequestedBy? RequestedBy,

    [property: JsonProperty(PropertyName = "lastChangedBy", NullValueHandling = NullValueHandling.Ignore)]
    LastChangedBy? LastChangedBy,

    [property: JsonProperty(PropertyName = "logs", NullValueHandling = NullValueHandling.Ignore)]
    Logs? Logs);