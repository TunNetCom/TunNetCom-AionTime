using TimeLogService.Domain.Models.dbo;
using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TimeLogService.Domain.Models.Dbo;

public partial class WorkItem : BaseEntity
{
    public WorkItem(Guid tenantId) : base(tenantId)
    {
    }

    public int AzureId { get; set; }

    public int ProjectId { get; set; }

    public string? Title { get; set; }

    public string? Type { get; set; }

    public string? State { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string History { get; set; } = string.Empty;

    public string WorkItemUrl { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<WorkItemHistory>? WorkItemHistories { get; private set; }

    public virtual ICollection<WorkItemTimeLog>? WorkItemTimeLogs { get; private set; }

    public virtual ICollection<WorkItemComment>? WorkItemComments { get; private set; }
}