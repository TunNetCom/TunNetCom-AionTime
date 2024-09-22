
namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            _ = builder.ToTable("WorkItem");

            _ = builder.Property(e => e.Discription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            _ = builder.HasOne(d => d.Project).WithMany(p => p.WorkItems)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FKProjectTicket");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItem> entity);
    }
}