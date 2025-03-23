namespace IdentityService.Infrastructure.DbContext.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        _ = builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        _ = builder.Property(u => u.TenantId)
            .IsRequired();

        _ = builder
            .HasOne(u => u.Tenant)
            .WithMany(t => t.ApplicationUsers)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}