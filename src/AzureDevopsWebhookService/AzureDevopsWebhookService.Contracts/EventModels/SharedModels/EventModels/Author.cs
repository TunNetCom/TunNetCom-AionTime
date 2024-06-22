using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;
using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class Author([property: JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)] string? Name,
    [property: JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
    string? Email,

    [property: JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore)]
    DateTime Date);