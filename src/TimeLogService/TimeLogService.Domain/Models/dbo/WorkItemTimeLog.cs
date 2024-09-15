namespace TimeLogService.Domain.Models;

public partial class WorkItemTimeLog : BaseEntity
{
    public string? Description { get; set; }

    public DateTime? Time { get; set; }

    public int WorkItemId { get; set; }

    public virtual WorkItem? WorkItem { get; set; }
}