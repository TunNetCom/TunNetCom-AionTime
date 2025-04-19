namespace IdentityService.Application.Events.DomainEvents.Events;

public record class TenantCreatedDomainEvent(
    Guid TenantId,
    string AzureDevOpsPath,
    string GithubPath,
    string OrganizationName,
    string UserEmail) : INotification;