using TimeLogService.Contracts.AzureDevopsPublicApiTemporary;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.Settings;
using TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService;

namespace TimeLogService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AzureDevopsSettings azureDevopsSettings = new();
        configuration.GetSection("AzureDevopsSettings").Bind(azureDevopsSettings);

        bool isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
        string? connectionString = isDocker
           ? configuration.GetConnectionString("TimeLogContextDocker")
           : configuration.GetConnectionString("TimeLogContext");

        _ = services.AddScoped<MultiTenancyService>();
        _ = services.AddDbContext<TimeLogServiceDataBaseContext>(options =>
        {
            _ = options.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    _ = sqlOptions.EnableRetryOnFailure();
                });

            _ = options.EnableSensitiveDataLogging();
        });

        _ = services.AddHttpClient<IWorkItemExternalService, WorkItemExternalService>((serviceProvider, client) =>
        {
            client.BaseAddress = azureDevopsSettings.BaseUrlAzure;
        });

        _ = services.AddHttpClient<IProjectService, ProjectService>((serviceProvider, client) =>
        {
            client.BaseAddress = azureDevopsSettings.BaseUrlAzure;
        });

        _ = services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}