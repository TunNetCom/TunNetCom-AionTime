using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Links
{
    [JsonProperty("avatar", NullValueHandling = NullValueHandling.Ignore)]
    public Avatar? Avatar { get; set; }
}