namespace TimeLogService.Domain.Models.Dbo;

public partial class WorkItem : BaseEntity
{
    public string? Discription { get; set; }

    public int ProjectId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<WorkItemHistory>? WorkItemHistories { get; private set; }

    public virtual ICollection<WorkItemTimeLog>? WorkItemTimeLogs { get; private set; }
}