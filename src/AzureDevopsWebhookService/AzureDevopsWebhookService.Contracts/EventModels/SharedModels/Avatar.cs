using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Avatar
{
    [JsonProperty("href")]
    public string? Href { get; set; }
}