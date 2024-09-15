namespace TimeLogService.Domain.Models;

public partial class AionTimeSubscription : BaseEntity
{
    public DateTime? SubsecriptionDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int OrganizationId { get; set; }

    public virtual IReadOnlyCollection<AionTimeSubscriptionHistory>? AionTimeSubscriptionHistories { get; set; } // = new List<AionTimeSubscriptionHistory>();

    public virtual Organization? Organization { get; set; }
}