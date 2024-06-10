using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Collection
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}