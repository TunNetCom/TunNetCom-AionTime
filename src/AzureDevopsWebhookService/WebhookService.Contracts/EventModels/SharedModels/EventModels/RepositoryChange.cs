namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record RepositoryChange(
    [property: JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
    string? Type,

    [property: JsonProperty(PropertyName = "change", NullValueHandling = NullValueHandling.Ignore)]
    Change? Job,

    [property: JsonProperty(PropertyName = "job", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Url);