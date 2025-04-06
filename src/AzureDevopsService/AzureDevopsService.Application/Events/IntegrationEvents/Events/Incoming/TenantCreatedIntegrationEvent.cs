namespace AzureDevopsService.Application.Events.IntegrationEvents.Events.Incoming;

public record TenantCreatedIntegrationEvent(
    string Email,

    string Path,

    string TenantId,

    string OrganizationId,

    string OrganizationName) : IntegrationEvent;