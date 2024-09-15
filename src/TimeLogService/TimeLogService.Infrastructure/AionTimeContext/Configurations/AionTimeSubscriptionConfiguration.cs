namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionConfiguration : IEntityTypeConfiguration<AionTimeSubscription>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscription> entity)
        {
            entity.ToTable("AionTimeSubscription");

            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.SubsecriptionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Organization).WithMany(p => p.AionTimeSubscriptions)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FKOrganizationSubscription");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscription> entity);
    }
}