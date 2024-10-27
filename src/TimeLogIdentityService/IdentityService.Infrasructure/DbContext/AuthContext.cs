#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Infrastructure.DbContext;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<IdentityUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        _ = builder.ApplyConfigurationsFromAssembly(typeof(AuthContext).Assembly);
    }
}