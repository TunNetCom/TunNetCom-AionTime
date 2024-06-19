using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;
using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class Avatar
{
    [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
    public string? Href { get; set; }
}