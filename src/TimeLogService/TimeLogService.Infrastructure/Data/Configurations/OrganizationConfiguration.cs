namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            _ = builder.ToTable("Organization");

            _ = builder.HasIndex(e => e.Name, "IX_Organization_Name_Unique").IsUnique();
            _ = builder.Property(e => e.TenantId).HasMaxLength(100);

            _ = builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Organization> entity);
    }
}