using TimeLogService.Infrastructure.AionTimeContext.Configurations;

public partial class TimeLogServiceDataBaseContext : DbContext
{
    public TimeLogServiceDataBaseContext(DbContextOptions<TimeLogServiceDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AionTimeSubscription> AionTimeSubscriptions { get; set; }

    public virtual DbSet<AionTimeSubscriptionHistory> AionTimeSubscriptionHistories { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkItem> WorkItems { get; set; }

    public virtual DbSet<WorkItemHistory> WorkItemHistories { get; set; }

    public virtual DbSet<WorkItemTimeLog> WorkItemTimeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AionTimeSubscriptionConfiguration());
        modelBuilder.ApplyConfiguration(new AionTimeSubscriptionHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        modelBuilder.ApplyConfiguration(new WorkItemHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new WorkItemTimeLogConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}