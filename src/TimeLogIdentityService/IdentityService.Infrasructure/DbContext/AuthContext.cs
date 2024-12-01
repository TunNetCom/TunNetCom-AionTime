#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using IdentityService.Domain.Models.Dbo;

namespace IdentityService.Infrastructure.DbContext;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<GitHubInfo> GitHubInfo { get; set; }

    public DbSet<AzureInfo> AzureInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(AuthContext).Assembly);

        _ = builder.Entity<AzureInfo>()
            .HasOne(ug => ug.User)
            .WithMany()
            .HasForeignKey(ug => ug.IdentityUserId)
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.Entity<GitHubInfo>()
            .HasOne(ug => ug.User)
            .WithMany()
            .HasForeignKey(ug => ug.IdentityUserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}