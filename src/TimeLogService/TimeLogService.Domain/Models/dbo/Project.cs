namespace TimeLogService.Domain.Models.Dbo;

public partial class Project : BaseEntity
{
    public int OrganizationId { get; set; }

    public virtual Organization? Organization { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public virtual ICollection<WorkItem>? WorkItems { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
}