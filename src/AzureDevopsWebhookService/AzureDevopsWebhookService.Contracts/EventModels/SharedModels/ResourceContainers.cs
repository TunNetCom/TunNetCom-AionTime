using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class ResourceContainers
{
    [JsonProperty("collection", NullValueHandling = NullValueHandling.Ignore)]
    public Collection? Collection { get; set; }

    [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
    public Account? Account { get; set; }

    [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
    public Project? Project { get; set; }
}