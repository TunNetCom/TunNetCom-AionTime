using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repositories;
using TunNetCom.AionTime.TimeLogService.Infrastructure.Repositories;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = services.AddDbContext<TunNetComAionTimeTimeLogServiceDataBaseContext>(options =>
        {
            _ = options.UseSqlServer(
                configuration.GetConnectionString("TimeLogContext"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    _ = sqlOptions.EnableRetryOnFailure();
                });
        });
        _ = services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}