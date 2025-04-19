namespace TimeLogService.Application.Features.ProjectActions.Commands;

public record CreateProjectCommand(
    int OrganizationId,
    Guid AzureProjectId,
    string Name,
    Uri Url,
    string State,
    int Revision,
    string? Visibility,
    DateTime? LastUpdateTime,
    Guid TenantId) : IRequest<int>;

