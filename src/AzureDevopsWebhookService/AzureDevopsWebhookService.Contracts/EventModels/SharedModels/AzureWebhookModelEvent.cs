using MediatR;
using System.Net;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public record AzureWebhookModelEvent<T>(
    [property: JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    string? Id,

    [property: JsonProperty(PropertyName = "eventType", NullValueHandling = NullValueHandling.Ignore)]
    string? EventType,

    [property: JsonProperty(PropertyName = "publisherId", NullValueHandling = NullValueHandling.Ignore)]
    string? PublisherId,

    [property: JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
    Message? Message,

    [property: JsonProperty(PropertyName = "detailedMessage", NullValueHandling = NullValueHandling.Ignore)]
    Message? DetailedMessage,

    [property: JsonProperty(PropertyName = "resource", NullValueHandling = NullValueHandling.Ignore)]
    T? Resource,

    [property: JsonProperty(PropertyName = "resourceVersion", NullValueHandling = NullValueHandling.Ignore)]
    string? ResourceVersion,

    [property: JsonProperty(PropertyName = "resourceContainers", NullValueHandling = NullValueHandling.Ignore)]
    ResourceContainers? ResourceContainers,

    [property: JsonProperty(PropertyName = "createdDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime CreatedDate) : IRequest<HttpStatusCode>
    where T : class;