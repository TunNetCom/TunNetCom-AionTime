namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionHistoryConfiguration : IEntityTypeConfiguration<AionTimeSubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscriptionHistory> entity)
        {
            _ = entity.ToTable("AionTimeSubscriptionHistory");

            _ = entity.Property(e => e.Id).ValueGeneratedNever();
            _ = entity.Property(e => e.SubscriptionDate).HasColumnType("date");

            _ = entity.HasOne(d => d.Subscription).WithMany(p => p.AionTimeSubscriptionHistories)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("FKSubscriptionSubscriptionHistory");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscriptionHistory> entity);
    }
}