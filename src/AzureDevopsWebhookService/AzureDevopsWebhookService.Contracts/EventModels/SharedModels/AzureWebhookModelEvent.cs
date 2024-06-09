using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class AzureWebhookModelEvent
{
    public string? Id { get; set; }

    public string? EventType { get; set; }

    public string? PublisherId { get; set; }

    public Message? Message { get; set; }

    public Message? DetailedMessage { get; set; }

    [JsonProperty("resource")]
    public Resource? Resource { get; set; }

    [JsonProperty("resourceVersion")]
    public string? ResourceVersion { get; set; }

    [JsonProperty("resourceContainers")]
    public ResourceContainers? ResourceContainers { get; set; }

    public DateTime CreatedDate { get; set; }
}