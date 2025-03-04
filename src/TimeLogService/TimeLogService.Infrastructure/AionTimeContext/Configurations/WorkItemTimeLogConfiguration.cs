namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemTimeLogConfiguration : IEntityTypeConfiguration<WorkItemTimeLog>
    {
        public void Configure(EntityTypeBuilder<WorkItemTimeLog> builder)
        {
            _ = builder.ToTable("WorkItemTimeLog");

            _ = builder.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            _ = builder.Property(e => e.Time).HasColumnType("datetime");
            _ = builder.Property(e => e.TenantId).HasMaxLength(100);
            _ = builder.HasOne(d => d.WorkItem).WithMany(p => p.WorkItemTimeLogs)
                .HasForeignKey(d => d.WorkItemId)
                .HasConstraintName("FKProjectTicketLog");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItemTimeLog> entity);
    }
}