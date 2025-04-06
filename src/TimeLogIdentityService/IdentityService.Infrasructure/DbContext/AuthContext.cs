namespace IdentityService.Infrastructure.DbContext;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public required DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        _ = builder.ApplyConfiguration(new ApplicationUserConfiguration());
        _ = builder.ApplyConfiguration(new TenantConfiguration());

        base.OnModelCreating(builder);
    }
}