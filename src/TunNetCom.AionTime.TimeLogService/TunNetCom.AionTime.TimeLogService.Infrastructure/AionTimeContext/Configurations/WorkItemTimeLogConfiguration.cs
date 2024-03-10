namespace TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class WorkItemTimeLogConfiguration : IEntityTypeConfiguration<WorkItemTimeLog>
{
    public void Configure(EntityTypeBuilder<WorkItemTimeLog> entity)
    {
        entity.HasOne(d => d.WorkItem).WithMany(p => p.WorkItemTimeLogs).HasConstraintName("FKProjectTicketLog");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WorkItemTimeLog> entity);
}
