using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;
using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Avatar(
    [property: JsonProperty(PropertyName = "href", NullValueHandling = NullValueHandling.Ignore)]
    Uri? Href);