using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Reviewer
{
    [JsonProperty("reviewerUrl")]
    public string? ReviewerUrl { get; set; }

    [JsonProperty("vote")]
    public int Vote { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("uniqueName")]
    public string? UniqueName { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonProperty("isContainer")]
    public bool IsContainer { get; set; }
}