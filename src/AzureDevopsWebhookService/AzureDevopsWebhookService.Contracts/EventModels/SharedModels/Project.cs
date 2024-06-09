using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Project
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("state")]
    public string? State { get; set; }

    [JsonProperty("revision")]
    public int Revision { get; set; }

    [JsonProperty("visibility")]
    public string? Visibility { get; set; }

    [JsonProperty("lastUpdateTime")]
    public string? LastUpdateTime { get; set; }
}