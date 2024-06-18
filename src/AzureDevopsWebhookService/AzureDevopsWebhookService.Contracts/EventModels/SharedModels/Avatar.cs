using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Avatar
{
    [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
    public string? Href { get; set; }
}