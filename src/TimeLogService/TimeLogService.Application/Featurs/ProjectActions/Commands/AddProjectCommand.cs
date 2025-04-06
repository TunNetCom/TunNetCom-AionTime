using System.Collections.ObjectModel;
using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.ProjectActions.Commands;
using Project = TimeLogService.Domain.Models.Dbo.Project;

namespace TimeLogService.Application.Featurs.ProjectActions.Commands;

public record AddProjectCommand(ReadOnlyCollection<Project> Projects) : IRequest<List<string>>;