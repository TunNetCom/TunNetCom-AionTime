namespace AzureDevopsService.Application.Events.IntegrationEvents.Events.Incoming;

public record TenantCreatedIntegrationEvent(
    string Email,

    string Pat,

    Guid TenantId,

    string OrganizationName) : IntegrationEvent;