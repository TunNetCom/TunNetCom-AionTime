namespace IdentityService.Application.Features.InternalTreatement.Events.TenatCreated;

public record class TenantCreatedNotification(Guid TenantId, string AzureDevOpsPath, string GithubPath, string UserEmail) : INotification;