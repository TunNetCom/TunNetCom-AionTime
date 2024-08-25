namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Change(
    [property: JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore)]
    Author? Author,

    [property: JsonProperty(PropertyName = "committer", NullValueHandling = NullValueHandling.Ignore)]
    Committer? Committer);