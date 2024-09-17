namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            _ = entity.ToTable("Project");

            _ = entity.HasIndex(e => e.ProjectId, "IX_Project_ProjectId").IsUnique();

            _ = entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            _ = entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = entity.Property(e => e.ProjectId).HasMaxLength(100);
            _ = entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
            _ = entity.Property(e => e.Visibility)
                .HasMaxLength(50)
                .IsUnicode(false);

            _ = entity.HasOne(d => d.Organization).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganisationProject");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Project> entity);
    }
}