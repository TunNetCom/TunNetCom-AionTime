namespace TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> entity)
    {
        entity.ToTable("Organization");

        entity.HasIndex(e => e.AccountId, "IX_Organization_AccountId").IsUnique();

        entity.HasIndex(e => e.Name, "IX_Organization_Name_Unique").IsUnique();

        entity.Property(e => e.AccountId).HasMaxLength(100);
        entity.Property(e => e.AccountUri)
            .HasMaxLength(200)
            .IsUnicode(false);
        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);
        entity.Property(e => e.UserId).HasMaxLength(100);

        entity.HasOne(d => d.User).WithMany(p => p.Organizations)
            .HasPrincipalKey(p => p.UserId)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FKUserOrganization");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<Organization> entity);
}
