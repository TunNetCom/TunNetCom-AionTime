namespace TimeLogService.Application.Featurs.ProjectActions.Commands;

public class AddProjectCommandHandler(IRepository<Project> repository) : IRequestHandler<AddProjectCommand, List<string>>
{
    public async Task<List<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        await repository.AddRangeAsync(request.Projects);

        return [.. request.Projects.Select(x => x.AzureProjectId.ToString())];
    }
}