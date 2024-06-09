using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class RefUpdate
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("oldObjectId")]
    public string? OldObjectId { get; set; }

    [JsonProperty("newObjectId")]
    public string? NewObjectId { get; set; }
}