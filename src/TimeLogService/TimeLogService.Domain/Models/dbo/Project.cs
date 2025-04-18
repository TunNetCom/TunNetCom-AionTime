using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TimeLogService.Domain.Models.Dbo;

public class Project : BaseEntity, IEntity
{
    public Project(int organizationId,
                   Guid azureProjectId,
                   string name,
                   string state,
                   string? visibility,
                   DateTime? lastUpdateTime,
                   Uri url,
                   Guid tenantId)
        : base(tenantId)
    {
        OrganizationId = organizationId;
        AzureProjectId = azureProjectId;
        Name = name;
        State = state;
        Visibility = visibility;
        LastUpdateTime = lastUpdateTime;
        Url = url;
        TenantId = tenantId;
    }

    public static Project Create(
        int organizationId,
        Guid azureProjectId,
        string name,
        string state,
        string? visibility,
        DateTime? lastUpdateTime,
        Uri url,
        Guid tenantId)
    {
        return new Project(
            organizationId: organizationId,
            azureProjectId: azureProjectId,
            name: name,
            state: state,
            visibility: visibility,
            lastUpdateTime: lastUpdateTime,
            url: url,
            tenantId: tenantId);
    }

    public int OrganizationId { get; private set; }

    public Guid AzureProjectId { get; private set; }

    public string Name { get; private set; }

    public string State { get; private set; }

    public string? Visibility { get; private set; }

    public DateTime? LastUpdateTime { get; private set; }

    public Uri Url { get; private set; }

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<WorkItem>? WorkItems { get; private set; }
}
