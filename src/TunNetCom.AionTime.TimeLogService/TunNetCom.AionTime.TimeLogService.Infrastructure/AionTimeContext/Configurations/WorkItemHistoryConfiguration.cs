namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class WorkItemHistoryConfiguration : IEntityTypeConfiguration<WorkItemHistory>
{
    public void Configure(EntityTypeBuilder<WorkItemHistory> entity)
    {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.HasOne(d => d.WorkItem).WithMany(p => p.WorkItemHistories).HasConstraintName("FKTicketHistory");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WorkItemHistory> entity);
}
