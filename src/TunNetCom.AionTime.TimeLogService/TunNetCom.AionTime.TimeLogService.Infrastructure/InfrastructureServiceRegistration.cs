namespace TunNetCom.AionTime.TimeLogService.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TunNetCom.AionTime.TimeLogService.Infrastructure.Repository;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TunNetComAionTimeTimeLogServiceDataBaseContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("TimeLogContext"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
        });
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}
