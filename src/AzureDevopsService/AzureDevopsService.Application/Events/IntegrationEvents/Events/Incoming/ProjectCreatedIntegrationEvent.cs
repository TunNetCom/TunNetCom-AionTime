namespace AzureDevopsService.Application.Events.IntegrationEvents.Events.Incoming;

internal record class ProjectCreatedIntegrationEvent(

     string Email,

     string Path,

     string TenantId,

     OrganizationObject Organizations) : IntegrationEvent;

internal record OrganizationObject
{
    public required string OrganizationName { get; set; }

    public required string OrganizationId { get; set; }

    public required List<string> ProjectsIds { get; set; }
}