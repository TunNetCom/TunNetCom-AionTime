using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class LastChangedBy
{
    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("_links")]
    public Links? Links { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("uniqueName")]
    public string? UniqueName { get; set; }

    [JsonProperty("imageUrl")]
    public string? ImageUrl { get; set; }

    [JsonProperty("descriptor")]
    public string? Descriptor { get; set; }
}