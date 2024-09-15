namespace TimeLogService.Domain.Models;

public partial class AionTimeSubscriptionHistory : BaseEntity
{
    public int SubscriptionId { get; set; }

    public DateTime SubscriptionDate { get; set; }

    public virtual AionTimeSubscription? Subscription { get; set; }
}