using AzureDevopsService.Contracts.Internal.Interfaces;
using Mapster;

namespace AzureDevopsService.Application.Events.IntegrationEvents.EventsHandlers;

public class TenantCreatedIntegrationEventHandler(
    ILogger<TenantCreatedIntegrationEventHandler> logger,
    IProjectService projectService,
    IEventBus eventBus) : IIntegrationEventHandler<TenantCreatedIntegrationEvent>
{
    public async Task Handle(TenantCreatedIntegrationEvent @event)
    {
        logger.LogInformation("Handling integration event: {IntegrationEventId} - ({@IntegrationEvent})", @event.Id, @event);

        OneOf<OrganizationProjectsResponce, CustomProblemDetailsResponce> projectsResponse =
            await projectService.AllProjectUnderOrganization(@event.OrganizationName, @event.Pat);

        if (projectsResponse.IsT0)
        {
            TenantOrganizationProjectsRetrivedIntegrationEvent organizationProjectsResponse = new(
                Email: @event.Email,
                Path: @event.Pat,
                TenantId: @event.TenantId,
                OrganizationName: @event.OrganizationName,
                OrganizationProjects: projectsResponse.AsT0.Adapt<OrganizationProjects>());

            await eventBus.PublishAsync(organizationProjectsResponse);
        }
    }
}