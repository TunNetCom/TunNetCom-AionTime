namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionConfiguration : IEntityTypeConfiguration<AionTimeSubscription>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscription> entity)
        {
            _ = entity.ToTable("AionTimeSubscription");

            _ = entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            _ = entity.Property(e => e.SubsecriptionDate).HasColumnType("datetime");

            _ = entity.HasOne(d => d.Organization).WithMany(p => p.AionTimeSubscriptions)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganizationSubscription");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscription> entity);
    }
}