namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> entity)
        {
            entity.ToTable("WorkItem");

            entity.Property(e => e.Discription)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Project).WithMany(p => p.WorkItems)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FKProjectTicket");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<WorkItem> entity);
    }
}