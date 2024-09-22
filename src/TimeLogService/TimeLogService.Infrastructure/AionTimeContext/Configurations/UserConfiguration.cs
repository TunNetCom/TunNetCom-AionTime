
namespace TimeLogService.Infrastructure.AionTimeContext.Configurations
{
    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.ToTable("User");

            _ = builder.HasIndex(e => e.UserId, "IX_User_UserId").IsUnique();

            _ = builder.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            _ = builder.Property(e => e.PublicAlias).HasMaxLength(100);
            _ = builder.Property(e => e.TimeStamp).HasColumnType("datetime");
            _ = builder.Property(e => e.UserId).HasMaxLength(100);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
    }
}