namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            _ = builder.ToTable("Project");

            _ = builder.HasIndex(e => e.ProjectId, "IX_Project_ProjectId").IsUnique();

            _ = builder.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            _ = builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = builder.Property(e => e.ProjectId).HasMaxLength(100);
            _ = builder.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
            _ = builder.Property(e => e.Visibility)
                .HasMaxLength(50)
                .IsUnicode(false);

            _ = builder.HasOne(d => d.Organization).WithMany(p => p.Projects)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganisationProject");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Project> entity);
    }
}