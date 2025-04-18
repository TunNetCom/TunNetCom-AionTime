namespace TimeLogService.Application.Features.ProjectActions.Commands;

public record CreateProjectCommand(
    int OrganizationId,
    Guid AzureProjectId,
    string Name,
    string State,
    string Visibility,
    DateTime LastUpdateTime) : IRequest<int>;

