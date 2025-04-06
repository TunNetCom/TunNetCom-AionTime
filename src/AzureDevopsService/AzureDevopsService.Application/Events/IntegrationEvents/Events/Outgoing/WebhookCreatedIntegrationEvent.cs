namespace AzureDevopsService.Application.Events.IntegrationEvents.Events.Outgoing;

public record class WebhookCreatedIntegrationEvent(

     string Email,

     string Path,

     string TenantId,

     ReadOnlyCollection<WebhookResponce> SubscriptionList) : IntegrationEvent;