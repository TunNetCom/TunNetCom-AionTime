namespace TunNetCom.AionTime.AzureDevopsService.API.Data;

public partial class AzureDevOpsContext(DbContextOptions<AzureDevOpsContext> options) : DbContext(options)
{
    public virtual DbSet<AzureDevopsHistory> AzureDevopsHistories { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new AzureDevopsHistoryConfiguration());
        _ = modelBuilder.ApplyConfiguration(new OrganizationConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}