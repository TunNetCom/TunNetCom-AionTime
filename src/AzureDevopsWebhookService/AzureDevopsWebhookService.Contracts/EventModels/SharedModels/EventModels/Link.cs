namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Link(
    [property: JsonProperty(PropertyName = "self", NullValueHandling = NullValueHandling.Ignore)]
    Url? Self,

    [property: JsonProperty(PropertyName = "workItemUpdates", NullValueHandling = NullValueHandling.Ignore)]
    Url? WorkItemUpdates,

    [property: JsonProperty(PropertyName = "workItemRevisions", NullValueHandling = NullValueHandling.Ignore)]
    Url? WorkItemRevisions,

    [property: JsonProperty(PropertyName = "workItemType", NullValueHandling = NullValueHandling.Ignore)]
    Url? WorkItemType,

    [property: JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
    Url? Fields,

    [property: JsonProperty(PropertyName = "html", NullValueHandling = NullValueHandling.Ignore)]
    Url? Html,

    [property: JsonProperty(PropertyName = "workItemHistory", NullValueHandling = NullValueHandling.Ignore)]
    Url? WorkItemHistory);