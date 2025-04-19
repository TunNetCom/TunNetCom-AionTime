using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Application.Features.ProjectActions.Commands;

public class CreateProjectCommandHandler(
        IRepository<Project> projectRepository,
        ILogger<CreateProjectCommandHandler> logger)
        : IRequestHandler<CreateProjectCommand, int>
{
    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Creating new project. OrganizationId: {OrganizationId}, ProjectName: {ProjectName}, AzureProjectId: {AzureProjectId}",
            request.OrganizationId,
            request.Name,
            request.AzureProjectId);

        var project = Project.Create(
            organizationId: request.OrganizationId,
            azureProjectId: request.AzureProjectId,
            name: request.Name,
            url: request.Url,
            state: request.State,
            revision: request.Revision,
            visibility: request.Visibility,
            lastUpdateTime: request.LastUpdateTime,
            tenantId: request.TenantId);

        await projectRepository.AddAsync(project, cancellationToken);

        logger.LogInformation(
            "Successfully created project. ProjectId: {ProjectId}, OrganizationId: {OrganizationId}, Name: {ProjectName}",
            project.Id,
            project.OrganizationId,
            project.Name);

        return project.Id;
    }
}