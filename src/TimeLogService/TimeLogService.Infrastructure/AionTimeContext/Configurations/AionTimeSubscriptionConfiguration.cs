namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionConfiguration : IEntityTypeConfiguration<AionTimeSubscription>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscription> builder)
        {
            _ = builder.ToTable("AionTimeSubscription");

            _ = builder.Property(e => e.ExpirationDate).HasColumnType("datetime");
            _ = builder.Property(e => e.SubsecriptionDate).HasColumnType("datetime");

            _ = builder.HasOne(d => d.Organization).WithMany(p => p.AionTimeSubscriptions)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganizationSubscription");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscription> entity);
    }
}