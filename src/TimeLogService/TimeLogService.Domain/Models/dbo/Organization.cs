namespace TimeLogService.Domain.Models;

public partial class Organization : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string AccountUri { get; set; } = null!;

    public bool IsAionTimeApproved { get; set; }

    public virtual ICollection<AionTimeSubscription>?  AionTimeSubscriptions { get; set; } //= new List<AionTimeSubscription>();

    public virtual ICollection<Project>?  Projects { get; set; } //= new List<Project>();

    public virtual User? User { get; set; }
}