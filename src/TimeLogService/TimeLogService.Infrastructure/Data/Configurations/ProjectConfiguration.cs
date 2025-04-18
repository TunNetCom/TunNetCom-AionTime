namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            _ = builder.ToTable("Project");

            _ = builder.Property(e => e.TenantId).HasMaxLength(100);
            _ = builder.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            _ = builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = builder.Property(e => e.AzureProjectId).HasMaxLength(100);
            _ = builder.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
            _ = builder.Property(e => e.Visibility)
                .HasMaxLength(50)
                .IsUnicode(false);

            _ = builder.HasOne(d => d.Organization).WithMany(p => p.Projects)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganisationProject");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Project> entity);
    }
}