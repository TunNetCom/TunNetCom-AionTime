namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

public partial class Project : BaseEntity
{
    public int OrganizationId { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<WorkItem>?  WorkItems { get; set; } //= new List<WorkItem>();
}