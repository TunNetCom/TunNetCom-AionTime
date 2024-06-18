using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class RefUpdate
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("oldObjectId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OldObjectId { get; set; }

    [JsonProperty("newObjectId", NullValueHandling = NullValueHandling.Ignore)]
    public string? NewObjectId { get; set; }
}