namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record AzurePipeline(
    [property: JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    int? Id,

    [property: JsonProperty(PropertyName = "revision", NullValueHandling = NullValueHandling.Ignore)]
    int? Revision,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "folder", NullValueHandling = NullValueHandling.Ignore)]
    string? Folder);