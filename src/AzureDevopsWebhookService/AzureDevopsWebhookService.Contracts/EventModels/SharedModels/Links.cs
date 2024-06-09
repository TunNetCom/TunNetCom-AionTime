using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Links
{
    [JsonProperty("avatar")]
    public Avatar? Avatar { get; set; }
}