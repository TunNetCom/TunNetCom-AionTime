using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Repository
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("project")]
    public Project? Project { get; set; }

    [JsonProperty("defaultBranch")]
    public string? DefaultBranch { get; set; }

    [JsonProperty("remoteUrl")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? RemoteUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings
}