using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix
public class Collection
#pragma warning restore CA1711 // Identifiers should not have incorrect suffix
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}