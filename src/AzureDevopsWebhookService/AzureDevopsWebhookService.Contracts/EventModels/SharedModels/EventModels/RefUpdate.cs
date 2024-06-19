using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class RefUpdate
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("oldObjectId", NullValueHandling = NullValueHandling.Ignore)]
    public string? OldObjectId { get; set; }

    [JsonProperty("newObjectId", NullValueHandling = NullValueHandling.Ignore)]
    public string? NewObjectId { get; set; }
}