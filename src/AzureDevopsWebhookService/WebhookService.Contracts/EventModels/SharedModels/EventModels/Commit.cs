namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Commit(
    [property: JsonProperty(PropertyName = "commitId", NullValueHandling = NullValueHandling.Ignore)]
    string? CommitId,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore)]
    Author? Author,

    [property: JsonProperty(PropertyName = "committer", NullValueHandling = NullValueHandling.Ignore)]
    Committer? Committer,

    [property: JsonProperty(PropertyName = "comment", NullValueHandling = NullValueHandling.Ignore)]
    string? Comment);