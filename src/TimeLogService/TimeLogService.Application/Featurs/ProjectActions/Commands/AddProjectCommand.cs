using Project = TimeLogService.Domain.Models.Dbo.Project;

namespace TimeLogService.Application.Featurs.ProjectActions.Commands;

public record AddProjectCommand(ReadOnlyCollection<Project> Projects) : IRequest<List<string>>;