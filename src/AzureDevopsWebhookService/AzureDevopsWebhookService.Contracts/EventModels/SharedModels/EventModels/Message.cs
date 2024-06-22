using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Message(
    [property: JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
    string? Text,

    [property: JsonProperty(PropertyName = "html", NullValueHandling = NullValueHandling.Ignore)]
    string? Html,

    [property: JsonProperty(PropertyName = "markdown", NullValueHandling = NullValueHandling.Ignore)]
    string? Markdown);