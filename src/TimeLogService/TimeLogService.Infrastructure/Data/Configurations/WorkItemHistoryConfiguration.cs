using TimeLogService.Domain.Entites;

namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemHistoryConfiguration : IEntityTypeConfiguration<WorkItemHistory>
    {
        public void Configure(EntityTypeBuilder<WorkItemHistory> builder)
        {
            _ = builder.ToTable("WorkItemHistory");

            _ = builder.Property(e => e.History)
                .HasMaxLength(1000)
                .IsUnicode(false);
            _ = builder.Property(e => e.TenantId).HasMaxLength(100);
            _ = builder.HasOne(d => d.WorkItem).WithMany(p => p.WorkItemHistories)
                .HasForeignKey(d => d.WorkItemId)
                .HasConstraintName("FKTicketHistory");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItemHistory> entity);
    }
}