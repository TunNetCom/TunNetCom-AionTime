namespace TimeLogService.Domain.Models;

public partial class Project : BaseEntity
{
    public int OrganizationId { get; set; }

    public string ProjectId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? State { get; set; }

    public string? Visibility { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public string Url { get; set; } = null!;

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<WorkItem>? WorkItems { get; set; } // = new List<WorkItem>();
}