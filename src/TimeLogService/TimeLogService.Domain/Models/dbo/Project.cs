namespace TimeLogService.Domain.Models.Dbo;

public class Project : BaseEntity, IEntity
{
    public Project(int organizationId,
                   Guid azureProjectId,
                   string name,
                   Uri url,
                   string state,
                   int revision,
                   string? visibility,
                   DateTime? lastUpdateTime,
                   Guid tenantId) : base(tenantId)
    {
        OrganizationId = organizationId;
        AzureProjectId = azureProjectId;
        Name = name;
        Url = url;
        State = state;
        Revision = revision;
        Visibility = visibility;
        LastUpdateTime = lastUpdateTime;
    }

    public static Project Create(int organizationId,
                          Guid azureProjectId,
                          string name,
                          Uri url,
                          string state,
                          int revision,
                          string? visibility,
                          DateTime? lastUpdateTime,
                          Guid tenantId)
    {
        return new Project(organizationId: organizationId,
                           azureProjectId: azureProjectId,
                           name: name,
                           url: url,
                           state: state,
                           revision: revision,
                           visibility: visibility,
                           lastUpdateTime: lastUpdateTime,
                           tenantId: tenantId);
    }

    public int OrganizationId { get; private set; }

    public Guid AzureProjectId { get; private set; }

    public string Name { get; private set; }

    public Uri Url { get; private set; }

    public string State { get; private set; }

    public int Revision { get; private set; }

    public string? Visibility { get; private set; }

    public DateTime? LastUpdateTime { get; private set; }

    public virtual Organization? Organization { get; private set; }

    public virtual ICollection<WorkItem>? WorkItems { get; private set; }
}
