using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Logs
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings
}