using TimeLogService.Application.Features.ProjectActions.Commands;

namespace TunNetCom.AzureDevOps.TimeLogService.Application.Features.Projects.Commands.CreateProjects;

public class CreateProjectsCommand : TenantCommand<Result<IEnumerable<int>>>
{
    public CreateProjectsCommand(Guid tenantId, IEnumerable<CreateProjectCommand> createProjectCommands) : base(tenantId)
    {
        CreateProjectCommands = createProjectCommands;
    }

    public int OrganizationId { get; }

    public IEnumerable<CreateProjectCommand> CreateProjectCommands{ get; set; }
}