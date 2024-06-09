using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class ResourceContainers
{
    [JsonProperty("collection")]
    public Collection? Collection { get; set; }

    [JsonProperty("account")]
    public Account? Account { get; set; }

    [JsonProperty("project")]
    public Project? Project { get; set; }
}