
namespace IdentityService.Infrastructure.DbContext;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<GitHubInfo> GitHubInfo { get; set; }

    public DbSet<AzureInfo> AzureInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(AuthContext).Assembly);

        _ = builder.Entity<ApplicationUser>()
            .HasOne(a => a.AzureInfo)
            .WithOne(u => u.User)
            .HasForeignKey<AzureInfo>(ai => ai.IdentityUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.Entity<ApplicationUser>()
            .HasOne(a => a.GitHubInfo)
            .WithOne(u => u.User)
            .HasForeignKey<GitHubInfo>(ai => ai.IdentityUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}