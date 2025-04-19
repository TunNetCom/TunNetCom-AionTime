using TimeLogService.Domain.Entites;

namespace TimeLogService.Infrastructure.AionTimeContext;

public partial class AzureDevOpsTimeLogDBContext(DbContextOptions<AzureDevOpsTimeLogDBContext> options)
    : DbContext(options)
{
    public virtual required DbSet<Organization> Organizations { get; set; }

    public virtual required DbSet<Project> Projects { get; set; }

    public virtual required DbSet<User> Users { get; set; }

    public virtual required DbSet<WorkItem> WorkItems { get; set; }

    public virtual required DbSet<WorkItemHistory> WorkItemHistories { get; set; }

    public virtual required DbSet<WorkItemTimeLog> WorkItemTimeLogs { get; set; }

    public virtual required DbSet<WorkItemComment> WorkItemComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
        _ = modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemHistoryConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemTimeLogConfiguration());
        _ = modelBuilder.ApplyConfiguration(new WorkItemCommentConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}