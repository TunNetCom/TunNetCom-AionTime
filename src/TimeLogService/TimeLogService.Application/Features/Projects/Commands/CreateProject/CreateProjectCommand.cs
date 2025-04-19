namespace TimeLogService.Application.Features.ProjectActions.Commands;

public class CreateProjectCommand : TenantCommand<Result<int>>
{
    public CreateProjectCommand(Guid tenantId,
                                int organizationId,
                                string name,
                                Uri url,
                                string state,
                                int revision,
                                string? visibility,
                                DateTime? lastUpdateTime) : base(tenantId)
    {
        OrganizationId = organizationId;
        Name = name;
        Url = url;
        State = state;
        Revision = revision;
        Visibility = visibility;
        LastUpdateTime = lastUpdateTime;
    }

    public int OrganizationId { get; }

    public Guid AzureProjectId { get; }

    public string Name { get; }

    public Uri Url { get; }

    public string State { get; }

    public int Revision { get; }

    public string? Visibility { get; }

    public DateTime? LastUpdateTime { get; }
}
