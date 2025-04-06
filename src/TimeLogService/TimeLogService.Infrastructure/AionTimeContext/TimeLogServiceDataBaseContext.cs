using TimeLogService.Infrastructure.AionTimeContext;
using TimeLogService.Infrastructure.AionTimeContext.Configurations;

namespace TimeLogService.Infrastructure.AionTimeContext;

public partial class TimeLogServiceDataBaseContext(DbContextOptions<TimeLogServiceDataBaseContext> options) : DbContext(options)
{
    public virtual required DbSet<AionTimeSubscription> AionTimeSubscriptions { get; set; }

    public virtual required DbSet<AionTimeSubscriptionHistory> AionTimeSubscriptionHistories { get; set; }

    public virtual required DbSet<Organization> Organizations { get; set; }

    public virtual required DbSet<Project> Projects { get; set; }

    public virtual required DbSet<User> Users { get; set; }

    public virtual required DbSet<WorkItem> WorkItems { get; set; }

    public virtual required DbSet<WorkItemHistory> WorkItemHistories { get; set; }

    public virtual required DbSet<WorkItemTimeLog> WorkItemTimeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new AionTimeSubscriptionConfiguration());
        _ = modelBuilder.ApplyConfiguration(new AionTimeSubscriptionHistoryConfiguration());
        _ = modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemHistoryConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemTimeLogConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}