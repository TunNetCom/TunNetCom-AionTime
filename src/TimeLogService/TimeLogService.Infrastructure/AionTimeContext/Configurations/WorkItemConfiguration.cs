namespace TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        _ = builder.ToTable("WorkItem");

        _ = builder.Property(e => e.Title)
            .HasMaxLength(1000)
            .IsUnicode(false);

        _ = builder.Property(e => e.TenantId).HasMaxLength(100);
        _ = builder.HasOne(d => d.Project).WithMany(p => p.WorkItems)
            .HasForeignKey(d => d.ProjectId)
            .HasConstraintName("FKProjectTicket");

        OnConfigurePartial(builder);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<WorkItem> entity);
}