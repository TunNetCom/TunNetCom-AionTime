using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class ResourceContainers
{
    [JsonProperty("collection", NullValueHandling = NullValueHandling.Ignore)]
    public Collection? Collection { get; set; }

    [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
    public Account? Account { get; set; }

    [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
    public Project? Project { get; set; }
}