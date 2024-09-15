namespace TimeLogService.Domain.Models;

public partial class WorkItem : BaseEntity
{
    public string? Discription { get; set; }

    public int ProjectId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual IReadOnlyCollection<WorkItemHistory>? WorkItemHistories { get; set; }

    public virtual IReadOnlyCollection<WorkItemTimeLog>? WorkItemTimeLogs { get; set; }
}