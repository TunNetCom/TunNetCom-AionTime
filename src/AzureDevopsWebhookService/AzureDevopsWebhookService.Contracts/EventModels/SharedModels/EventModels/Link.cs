namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Link(
    [property: JsonProperty(PropertyName = "self", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? Self,

    [property: JsonProperty(PropertyName = "workItemUpdates", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? WorkItemUpdates,

    [property: JsonProperty(PropertyName = "workItemRevisions", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? WorkItemRevisions,

    [property: JsonProperty(PropertyName = "workItemType", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? WorkItemType,

    [property: JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? Fields,

    [property: JsonProperty(PropertyName = "html", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? Html,

    [property: JsonProperty(PropertyName = "workItemHistory", NullValueHandling = NullValueHandling.Ignore)]
    Avatar? WorkItemHistory);