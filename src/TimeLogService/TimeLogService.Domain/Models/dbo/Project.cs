namespace TimeLogService.Domain.Models;

public partial class Project : BaseEntity
{
    public int OrganizationId { get; set; }

    public string ProjectId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? State { get; set; }

    public int? Revision { get; set; }

    public string? Visibility { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public string Url { get; set; } = null!;
}