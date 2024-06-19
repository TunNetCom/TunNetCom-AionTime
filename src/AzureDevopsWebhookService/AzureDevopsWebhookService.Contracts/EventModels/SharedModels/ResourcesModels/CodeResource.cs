using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.ResourcesModels
{
    public class CodeResource
    {
        [JsonProperty("repository", NullValueHandling = NullValueHandling.Ignore)]
        public Repository? Repository { get; set; }

        [JsonProperty("pullRequestId", NullValueHandling = NullValueHandling.Ignore)]
        public int? PullRequestId { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        [JsonProperty("createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public CreatedBy? CreatedBy { get; set; }

        [JsonProperty("creationDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("closedDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ClosedDate { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty("sourceRefName", NullValueHandling = NullValueHandling.Ignore)]
        public string? SourceRefName { get; set; }

        [JsonProperty("targetRefName", NullValueHandling = NullValueHandling.Ignore)]
        public string? TargetRefName { get; set; }

        [JsonProperty("mergeStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string? MergeStatus { get; set; }

        [JsonProperty("mergeId", NullValueHandling = NullValueHandling.Ignore)]
        public string? MergeId { get; set; }

        [JsonProperty("lastMergeSourceCommit", NullValueHandling = NullValueHandling.Ignore)]
        public BaseCommit? LastMergeSourceCommit { get; set; }

        [JsonProperty("lastMergeTargetCommit", NullValueHandling = NullValueHandling.Ignore)]
        public BaseCommit? LastMergeTargetCommit { get; set; }

        [JsonProperty("lastMergeCommit", NullValueHandling = NullValueHandling.Ignore)]
        public BaseCommit? LastMergeCommit { get; set; }

        [JsonProperty("reviewers", NullValueHandling = NullValueHandling.Ignore)]
        public Reviewer? Reviewers { get; set; }

        [JsonProperty("commits", NullValueHandling = NullValueHandling.Ignore)]
        public BaseCommit? Commits { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string? Url { get; set; }
    }
}