using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class AzureWebhookModelEvent<T>
    where T : class
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("eventType", NullValueHandling = NullValueHandling.Ignore)]
    public string? EventType { get; set; }

    [JsonProperty("publisherId", NullValueHandling = NullValueHandling.Ignore)]
    public string? PublisherId { get; set; }

    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public Message? Message { get; set; }

    [JsonProperty("detailedMessage", NullValueHandling = NullValueHandling.Ignore)]
    public Message? DetailedMessage { get; set; }

    [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
    public T? Resource { get; set; }

    [JsonProperty("resourceVersion", NullValueHandling = NullValueHandling.Ignore)]
    public string? ResourceVersion { get; set; }

    [JsonProperty("resourceContainers", NullValueHandling = NullValueHandling.Ignore)]
    public ResourceContainers? ResourceContainers { get; set; }

    public DateTime CreatedDate { get; set; }
}