using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Reviewer
{
    [JsonProperty("reviewerUrl")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? ReviewerUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("vote")]
    public int Vote { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("uniqueName")]
    public string? UniqueName { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("imageUrl")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? ImageUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("isContainer")]
    public bool IsContainer { get; set; }
}