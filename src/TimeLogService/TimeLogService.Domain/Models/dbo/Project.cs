namespace TimeLogService.Domain.Models.Dbo;

public partial class Project : BaseEntity
{
    public int OrganizationId { get; set; }

    public string ProjectId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? State { get; set; }

    public string? Visibility { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public required Uri Url { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<WorkItem>? WorkItems { get; private set; }
}