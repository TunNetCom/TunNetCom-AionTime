using WebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace WebhookService.Contracts.EventModels.SharedModels.ResourcesModels;

public record CodeResource(
    [property: JsonProperty(PropertyName = "Commits", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<Commit>? Commits,

    [property: JsonProperty(PropertyName = "repository", NullValueHandling = NullValueHandling.Ignore)]
    Repository? Repository,

    [property: JsonProperty(PropertyName = "pullRequestId", NullValueHandling = NullValueHandling.Ignore)]
    int? PullRequestId,

    [property: JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
    string? Status,

    [property: JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
    CreatedBy? CreatedBy,

    [property: JsonProperty(PropertyName = "creationDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? CreationDate,

    [property: JsonProperty(PropertyName = "closedDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? ClosedDate,

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
    BaseCommit? LastMergeSourceCommit,

    [property: JsonProperty(PropertyName = "lastMergeTargetCommit", NullValueHandling = NullValueHandling.Ignore)]
    BaseCommit? LastMergeTargetCommit,

    [property: JsonProperty(PropertyName = "lastMergeCommit", NullValueHandling = NullValueHandling.Ignore)]
    BaseCommit? LastMergeCommit,

    [property: JsonProperty(PropertyName = "reviewers", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<Reviewer>? Reviewers,

    [property: JsonProperty(PropertyName = "commit", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<BaseCommit>? Commit,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);