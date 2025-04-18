using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TimeLogService.Domain.Models.Dbo;

public partial class WorkItemTimeLog : BaseEntity
{
    public WorkItemTimeLog(Guid tenantId) : base(tenantId)
    {
    }

    public string? Description { get; set; }

    public DateTime? Time { get; set; }

    public int WorkItemId { get; set; }

    public virtual WorkItem? WorkItem { get; set; }
}