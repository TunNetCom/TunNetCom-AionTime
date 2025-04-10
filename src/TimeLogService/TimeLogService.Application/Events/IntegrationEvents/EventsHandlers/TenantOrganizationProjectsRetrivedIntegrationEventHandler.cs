namespace TimeLogService.Application.Events.IntegrationEvents.EventsHandlers;

public class TenantOrganizationProjectsRetrivedIntegrationEventHandler(
    ILogger<TenantOrganizationProjectsRetrivedIntegrationEventHandler> logger,
    IMediator mediator,
    IRepository<Project> repository,
    IEventBus eventBus) : IIntegrationEventHandler<TenantOrganizationProjectsRetrivedIntegrationEvent>
{
    public async Task Handle(TenantOrganizationProjectsRetrivedIntegrationEvent integrationEvent)
    {
        HashSet<Guid> existingProjectIds = [.. (await repository.GetAsync()).Select(x => x.AzureProjectId)];

        ReadOnlyCollection<Project> project = integrationEvent.OrganizationProjects.Value
            .Select(p => new Project()
            {
                OrganizationId = integrationEvent.OrganizationId,
                AzureProjectId = p.Id,
                Name = p.Name,
                Url = p.Url,
                Visibility = p.Visibility,
                LastUpdateTime = p.LastUpdateTime,
                State = p.State,
                TenantId = integrationEvent.TenantId,
            })
            .Where(x => !existingProjectIds.Contains(x.AzureProjectId))
            .ToList()
            .AsReadOnly();

        List<string> addedProjects = await mediator.Send(new AddProjectCommand(project));

        _ = eventBus.PublishAsync(new ProjectCreatedIntegrationEvent(
            Email: integrationEvent.Email,
            Path: integrationEvent.Path,
            TenantId: integrationEvent.TenantId,
            Organizations: new OrganizationObject
            {
                OrganizationId = integrationEvent.OrganizationId,
                OrganizationName = integrationEvent.OrganizationName,
                ProjectsIds = addedProjects,
            }));

        logger.LogInformation(JsonConvert.SerializeObject(integrationEvent));
    }
}