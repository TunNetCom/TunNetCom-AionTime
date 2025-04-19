namespace TunNetCom.AzureDevOps.TimeLogService.Application.Features.Projects.Commands.CreateProjects;

internal class CreateProjectsCommandHandler : IRequestHandler<CreateProjectsCommand, Result<IEnumerable<int>>>
{
    private readonly IRepository<Project> _projectRepository;
    private readonly ILogger<CreateProjectsCommandHandler> _logger;

    public CreateProjectsCommandHandler(
            IRepository<Project> projectRepository,
            ILogger<CreateProjectsCommandHandler> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<int>>> Handle(CreateProjectsCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Creating new projects. OrganizationId: {OrganizationId}, ProjectCount: {ProjectCount}",
            request.OrganizationId,
            request.CreateProjectCommands.Count());

        foreach(var command in request.CreateProjectCommands)
        {
            bool isProjectExist = await _projectRepository.IsPropertyExistAsync(
                p => p.AzureProjectId,
                command.AzureProjectId);

            if (isProjectExist)
            {
                _logger.LogWarning(
                    "Project with AzureProjectId: {AzureProjectId} already exists. Skipping creation.",
                    command.AzureProjectId);

                return Result.Fail<IEnumerable<int>>($"Project with AzureProjectId: {command.AzureProjectId} already exists.");
            }
        }

        var projects = request.CreateProjectCommands.Select(project =>
            Project.Create(
                project.OrganizationId,
                project.AzureProjectId,
                project.Name,
                project.Url,
                project.State,
                project.Revision,
                project.Visibility,
                project.LastUpdateTime,
                request.TenantId
            )).ToList();

        await _projectRepository.AddRangeAsync(projects, cancellationToken);

        IEnumerable<int> createdProjectIds = projects.Select(p => p.Id);

        _logger.LogInformation("Successfully created {Count} projects.", createdProjectIds.Count());

        return Result.Ok(createdProjectIds);
    }
}