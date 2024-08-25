namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Definition(
    [property: JsonProperty(PropertyName = "drafts", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<object>? Drafts,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    int Id,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "uri", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Uri,

    [property: JsonProperty(PropertyName = "path", NullValueHandling = NullValueHandling.Ignore)]
    string? Path,

    [property: JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
    string? Type,

    [property: JsonProperty(PropertyName = "queueStatus", NullValueHandling = NullValueHandling.Ignore)]
    string? QueueStatus,

    [property: JsonProperty(PropertyName = "revision", NullValueHandling = NullValueHandling.Ignore)]
    int Revision,

    [property: JsonProperty(PropertyName = "project", NullValueHandling = NullValueHandling.Ignore)]
    Project? Project);