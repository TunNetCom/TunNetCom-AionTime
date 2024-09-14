namespace TimeLogService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        bool isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
        string? connectionString = isDocker
           ? configuration.GetConnectionString("TimeLogContextDocker")
           : configuration.GetConnectionString("TimeLogContext");

        _ = services.AddScoped<MultiTenancyService>();
        _ = services.AddDbContext<TunNetComAionTimeTimeLogServiceDataBaseContext>(options =>
        {
            _ = options.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    _ = sqlOptions.EnableRetryOnFailure();
                });

            _ = options.EnableSensitiveDataLogging();
        });
        _ = services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}