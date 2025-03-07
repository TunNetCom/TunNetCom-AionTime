﻿namespace TimeLogService.Domain.Models.Dbo;

public partial class AionTimeSubscription : BaseEntity
{
    public DateTime? SubsecriptionDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int OrganizationId { get; set; }

    public virtual ICollection<AionTimeSubscriptionHistory>? AionTimeSubscriptionHistories { get; private set; }

    public virtual Organization? Organization { get; set; }
}