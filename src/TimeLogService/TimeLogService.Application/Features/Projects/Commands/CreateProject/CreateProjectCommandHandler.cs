namespace TimeLogService.Application.Features.ProjectActions.Commands;

public class CreateProjectCommandHandler(
        IRepository<Project> projectRepository,
        ILogger<CreateProjectCommandHandler> logger)
        : IRequestHandler<CreateProjectCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Creating new project. OrganizationId: {OrganizationId}, ProjectName: {ProjectName}, AzureProjectId: {AzureProjectId}",
            request.OrganizationId,
            request.Name,
            request.AzureProjectId);

        bool isProjectExist = await projectRepository.IsPropertyExistAsync(
            p => p.AzureProjectId,
            request.AzureProjectId);

        if (isProjectExist)
        {
            logger.LogWarning(
                "Project with AzureProjectId: {AzureProjectId} already exists. Skipping creation.",
                request.AzureProjectId);

            return Result.Fail<int>($"Project with AzureProjectId: {request.AzureProjectId} already exists.");
        }

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