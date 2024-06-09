using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Definition
{
    [JsonProperty("drafts")]
#pragma warning disable CA1819 // Properties should not return arrays
    public object[]? Drafts { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Url { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("uri")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string? Uri { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonProperty("path")]
    public string? Path { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("queueStatus")]
    public string? QueueStatus { get; set; }

    [JsonProperty("revision")]
    public int Revision { get; set; }

    [JsonProperty("project")]
    public Project? Project { get; set; }
}