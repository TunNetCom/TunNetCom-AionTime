namespace IdentityService.Infrastructure.DbContext.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        _ = builder.HasKey(t => t.Id);

        _ = builder.Property(t => t.Id)
            .HasDefaultValueSql("NEWID()");

        _ = builder.Property(t => t.OrganizationLandPhone)
            .HasMaxLength(20);

        _ = builder.Property(t => t.OrganizationMobilePhone)
            .HasMaxLength(20);

        _ = builder.Property(t => t.OrganizationEmail)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.Property(t => t.OrganizationDescription)
            .HasMaxLength(200);

        _ = builder.HasIndex(t => t.OrganizationName)
            .IsUnique();

        _ = builder.Property(t => t.OrganizationName)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.HasIndex(t => t.OrganizationEmail)
            .IsUnique();

        _ = builder.Property(t => t.IsActivated)
            .HasDefaultValue(false);
    }
}