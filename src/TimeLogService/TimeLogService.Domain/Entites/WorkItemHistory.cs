namespace TimeLogService.Domain.Entites;

public partial class WorkItemHistory : BaseEntity
{
    public WorkItemHistory(Guid tenantId) : base(tenantId)
    {
    }

    public string? History { get; set; }

    public int WorkItemId { get; set; }

    public virtual WorkItem? WorkItem { get; set; }
}