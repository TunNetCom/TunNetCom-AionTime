using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public class Definition
{
    [JsonProperty("drafts", NullValueHandling = NullValueHandling.Ignore)]
    public object[]? Drafts { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
    public string? Uri { get; set; }

    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string? Path { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string? Type { get; set; }

    [JsonProperty("queueStatus", NullValueHandling = NullValueHandling.Ignore)]
    public string? QueueStatus { get; set; }

    [JsonProperty("revision", NullValueHandling = NullValueHandling.Ignore)]
    public int Revision { get; set; }

    [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
    public Project? Project { get; set; }
}