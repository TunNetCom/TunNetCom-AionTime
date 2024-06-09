using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class PushedBy
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("uniqueName")]
    public string? UniqueName { get; set; }
}