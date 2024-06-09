using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class LastChangedBy
{
    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("_links")]
    public Links? Links { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("uniqueName")]
    public string? UniqueName { get; set; }

    [JsonProperty("imageUrl")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? ImageUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("descriptor")]
    public string? Descriptor { get; set; }
}