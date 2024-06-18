using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Project
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
    public string? State { get; set; }

    [JsonProperty("revision", NullValueHandling = NullValueHandling.Ignore)]
    public int Revision { get; set; }

    [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
    public string? Visibility { get; set; }

    [JsonProperty("lastUpdateTime", NullValueHandling = NullValueHandling.Ignore)]
    public string? LastUpdateTime { get; set; }
}