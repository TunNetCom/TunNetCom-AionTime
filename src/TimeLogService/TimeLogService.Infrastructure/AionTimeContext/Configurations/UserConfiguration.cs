namespace TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.ToTable("User");

        entity.HasIndex(e => e.UserId, "IX_User_UserId").IsUnique();

        entity.Property(e => e.EmailAddress)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.PublicAlias).HasMaxLength(100);
        entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        entity.Property(e => e.UserId).HasMaxLength(100);

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
}
