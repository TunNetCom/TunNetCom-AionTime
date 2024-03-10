namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> entity)
    {
        entity.HasOne(d => d.Project).WithMany(p => p.WorkItems).HasConstraintName("FKProjectTicket");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WorkItem> entity);
}
