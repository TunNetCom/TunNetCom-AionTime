namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class AionTimeSubscriptionHistoryConfiguration : IEntityTypeConfiguration<AionTimeSubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<AionTimeSubscriptionHistory> builder)
        {
            _ = builder.ToTable("AionTimeSubscriptionHistory");

            _ = builder.Property(e => e.Id).ValueGeneratedNever();
            _ = builder.Property(e => e.SubscriptionDate).HasColumnType("date");

            _ = builder.HasOne(d => d.Subscription).WithMany(p => p.AionTimeSubscriptionHistories)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("FKSubscriptionSubscriptionHistory");

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AionTimeSubscriptionHistory> entity);
    }
}