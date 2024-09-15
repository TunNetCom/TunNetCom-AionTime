namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionHistoryConfiguration : IEntityTypeConfiguration<AionTimeSubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscriptionHistory> entity)
        {
            entity.ToTable("AionTimeSubscriptionHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SubscriptionDate).HasColumnType("date");

            entity.HasOne(d => d.Subscription).WithMany(p => p.AionTimeSubscriptionHistories)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("FKSubscriptionSubscriptionHistory");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscriptionHistory> entity);
    }
}