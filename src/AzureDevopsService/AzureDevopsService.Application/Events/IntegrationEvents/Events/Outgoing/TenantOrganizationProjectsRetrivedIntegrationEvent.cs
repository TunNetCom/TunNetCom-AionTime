namespace AzureDevopsService.Application.Events.IntegrationEvents.Events.Outgoing;

internal record class TenantOrganizationProjectsRetrivedIntegrationEvent(
    string Email,
    string Path,
    Guid TenantId,
    string OrganizationName,
    OrganizationProjects OrganizationProjects) : IntegrationEvent;

internal record Project
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Uri? Url { get; set; }

    public string State { get; set; } = string.Empty;

    public int Revision { get; set; }

    public string Visibility { get; set; } = string.Empty;

    public DateTime LastUpdateTime { get; set; }
}

internal record OrganizationProjects
{
    public int Count { get; set; }

    public IEnumerable<Project> Value { get; set; } = Enumerable.Empty<Project>();
}