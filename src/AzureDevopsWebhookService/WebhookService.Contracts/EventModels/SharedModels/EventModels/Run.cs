namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Run(
    [property: JsonProperty(PropertyName = "pipeline", NullValueHandling = NullValueHandling.Ignore)]
    AzurePipeline? Pipeline,

    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    int? Id,

    [property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name,

    [property: JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
    string? DisplayName,

    [property: JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
    string? State,

    [property: JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
    string? Result,

    [property: JsonProperty(PropertyName = "startTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? StartTime,

    [property: JsonProperty(PropertyName = "finishTime", NullValueHandling = NullValueHandling.Ignore)]
    DateTime? FinishTime);