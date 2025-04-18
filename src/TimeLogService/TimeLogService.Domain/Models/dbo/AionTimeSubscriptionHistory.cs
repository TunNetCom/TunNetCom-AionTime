using TunNetCom.AionTime.SharedKernel.BaseEntites;

namespace TimeLogService.Domain.Models.Dbo;

public partial class AionTimeSubscriptionHistory : BaseEntity
{
    public AionTimeSubscriptionHistory(Guid tenantId) : base(tenantId)
    {
    }

    public int SubscriptionId { get; set; }

    public DateTime SubscriptionDate { get; set; }

    public virtual AionTimeSubscription? Subscription { get; set; }
}