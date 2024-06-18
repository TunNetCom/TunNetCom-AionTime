using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class RequestedFor
{
    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    public string? DisplayName { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
    public Links? Links { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("uniqueName", NullValueHandling = NullValueHandling.Ignore)]
    public string? UniqueName { get; set; }

    [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    public string? ImageUrl { get; set; }

    [JsonProperty("descriptor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Descriptor { get; set; }
}