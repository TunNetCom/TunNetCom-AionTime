namespace TimeLogService.Domain.Models.Dbo;

public partial class Project : BaseEntity
{
    public required string AccountId { get; set; }

    public Guid ProjectId { get; set; }

    public required string Name { get; set; }

    public required string State { get; set; }

    public string? Visibility { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public required Uri Url { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual ICollection<WorkItem>? WorkItems { get; private set; }
}