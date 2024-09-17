namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            _ = entity.ToTable("User");

            _ = entity.HasIndex(e => e.UserId, "IX_User_UserId").IsUnique();

            _ = entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = entity.Property(e => e.PublicAlias).HasMaxLength(100);
            _ = entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            _ = entity.Property(e => e.UserId).HasMaxLength(100);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
    }
}