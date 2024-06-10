using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Repository
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("project")]
    public Project? Project { get; set; }

    [JsonProperty("defaultBranch")]
    public string? DefaultBranch { get; set; }

    [JsonProperty("remoteUrl")]
    public string? RemoteUrl { get; set; }
}