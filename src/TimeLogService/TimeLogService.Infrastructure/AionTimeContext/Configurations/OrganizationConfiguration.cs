namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            _ = builder.ToTable("Organization");

            _ = builder.HasIndex(e => e.AccountId, "IX_Organization_AccountId").IsUnique();

            _ = builder.HasIndex(e => e.Name, "IX_Organization_Name_Unique").IsUnique();

            _ = builder.Property(e => e.AccountId).HasMaxLength(100);
            _ = builder.Property(e => e.AccountUri)
                .HasMaxLength(200)
                .IsUnicode(false);
            _ = builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            _ = builder.Property(e => e.UserId).HasMaxLength(100);

            _ = builder.HasOne(d => d.User).WithMany(p => p.Organizations)
                .HasPrincipalKey(p => p.UserId)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKUserOrganization");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Organization> entity);
    }
}