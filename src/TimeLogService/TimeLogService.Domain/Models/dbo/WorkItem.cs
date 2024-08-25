namespace TunNetCom.AionTime.TimeLogService.Domain.Models.Dbo;

public partial class WorkItem : BaseEntity
{
    public string? Discription { get; set; }

    public int ProjectId { get; set; }

    public virtual Project? Project { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public virtual ICollection<WorkItemHistory>? WorkItemHistories { get; set; }

    public virtual ICollection<WorkItemTimeLog>? WorkItemTimeLogs { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

}