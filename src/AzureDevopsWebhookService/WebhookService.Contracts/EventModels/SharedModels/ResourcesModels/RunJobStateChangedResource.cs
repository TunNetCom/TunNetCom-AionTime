using WebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace WebhookService.Contracts.EventModels.SharedModels.ResourcesModels;

public record class RunJobStateChangedResource(
    [property: JsonProperty(PropertyName = "job", NullValueHandling = NullValueHandling.Ignore)]
    Job? Job,

    [property: JsonProperty(PropertyName = "stage", NullValueHandling = NullValueHandling.Ignore)]
    Stage? Stage,

    [property: JsonProperty(PropertyName = "run", NullValueHandling = NullValueHandling.Ignore)]
    Run? Run,

    [property: JsonProperty(PropertyName = "pipeline", NullValueHandling = NullValueHandling.Ignore)]
    AzurePipeline? Pipeline,

    [property: JsonProperty(PropertyName = "repositories", NullValueHandling = NullValueHandling.Ignore)]
    IReadOnlyCollection<RepositoryChange>? Repositories);