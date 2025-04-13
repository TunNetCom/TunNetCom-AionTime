namespace TimeLogService.Application.Events.IntegrationEvents.Events.Outgoing.AzureDevopsIntegrationEvents;

internal record class ProjectCreatedIntegrationEvent(

 string Email,

 string Path,

 string TenantId,

 OrganizationObject Organizations) : IntegrationEvent;

internal record OrganizationObject
{
    public required string OrganizationName { get; set; }

    public  int OrganizationId { get; set; }

    public required List<string> ProjectsIds { get; set; }
}