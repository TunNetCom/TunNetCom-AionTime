namespace IdentityService.Infrastructure.DbContext.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        _ = builder.HasKey(t => t.Id);

        _ = builder.Property(t => t.Id)
            .HasDefaultValueSql("NEWID()");

        _ = builder.Property(t => t.LandPhone)
            .HasMaxLength(20);

        _ = builder.Property(t => t.MobilePhone)
            .HasMaxLength(20);

        _ = builder.Property(t => t.Email)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.Property(t => t.Description)
            .HasMaxLength(200);

        _ = builder.HasIndex(t => t.Name)
            .IsUnique();

        _ = builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.HasIndex(t => t.Email)
            .IsUnique();

        _ = builder.Property(t => t.IsActivated)
            .HasDefaultValue(false);
    }
}