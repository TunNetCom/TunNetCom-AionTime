using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Reviewer
{
    [JsonProperty("reviewerUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string? ReviewerUrl { get; set; }

    [JsonProperty("vote", NullValueHandling = NullValueHandling.Ignore)]
    public int Vote { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    public string? DisplayName { get; set; }

    [JsonProperty("uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    public string? UniqueName { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string? ImageUrl { get; set; }

    [JsonProperty("isContainer", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsContainer { get; set; }
}