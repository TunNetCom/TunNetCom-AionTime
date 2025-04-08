namespace TimeLogService.Application.Events.IntegrationEvents.Events.Incoming.AzureDevopsIntegrationEvents;

public record class TenantOrganizationProjectsRetrivedIntegrationEvent(
string Email,
string Path,
string TenantId,
string OrganizationId,
string OrganizationName,
OrganizationProjectsObject OrganizationProjects) : IntegrationEvent;

public record ProjectObject
{
    public Guid Id { get; }

    public string Name { get; } = string.Empty;

    public required Uri Url { get; set; }

    public string State { get; } = string.Empty;

    public int Revision { get; }

    public string Visibility { get; set; } = string.Empty;

    public DateTime LastUpdateTime { get; }
}

public record OrganizationProjectsObject
{
    public int Count { get; }

    public IEnumerable<ProjectObject> Value { get; } = Enumerable.Empty<ProjectObject>();
}