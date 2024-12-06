namespace TimeLogService.Domain.Models.Dbo;

public partial class Organization : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public required Uri AccountUri { get; set; }

    public bool IsAionTimeApproved { get; set; }

    public virtual ICollection<AionTimeSubscription>? AionTimeSubscriptions { get; private set; }

    public virtual ICollection<Project>? Projects { get; private set; }

    public virtual User? User { get; set; }
}