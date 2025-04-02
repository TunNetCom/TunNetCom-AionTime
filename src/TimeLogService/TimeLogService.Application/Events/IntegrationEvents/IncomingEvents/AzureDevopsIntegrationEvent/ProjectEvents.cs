using MassTransit.Initializers;
using MediatR;
using System.Collections.ObjectModel;
using System.Linq;
using TimeLogService.Application.Feature.ProjectAction.Commands;
using Project = TimeLogService.Domain.Models.Dbo.Project;

namespace TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.AzureDevopsIntegrationEvent;

public class ProjectEvents(ILogger<ProjectEvents> logger, IMediator mediator, IRepository<Project> repository) : IConsumer<GetOrganizationProjectsResponse>
{
    private readonly ILogger<ProjectEvents> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly IRepository<Project> _repository = repository;

    public async Task Consume(ConsumeContext<GetOrganizationProjectsResponse> context)
    {
        HashSet<Guid> existingProjectIds = [.. (await _repository.GetAsync()).Select(x => x.ProjectId)];

        ReadOnlyCollection<Project> project = context.Message.OrganizationProjects.Value
            .Select(p => new Project()
            {
                AccountId = context.Message.OrganizationId,
                ProjectId = p.Id,
                Name = p.Name,
                Url = p.Url ?? new Uri("http://default.url"),
                Visibility = p.Visibility,
                LastUpdateTime = p.LastUpdateTime,
                State = p.State,
                TenantId = context.Message.TenantId,
            })
            .Where(x => !existingProjectIds.Contains(x.ProjectId))
            .ToList()
            .AsReadOnly();

        await _mediator.Send(new AddProjectCommand(project));

        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}