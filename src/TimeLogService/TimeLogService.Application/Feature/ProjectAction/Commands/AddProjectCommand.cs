using System.Collections.ObjectModel;
using Project = TimeLogService.Domain.Models.Dbo.Project;

namespace TimeLogService.Application.Feature.ProjectAction.Commands;

public record class AddProjectCommand(ReadOnlyCollection<Project> Projects) : IRequest;