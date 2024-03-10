using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;
using TunNetCom.AionTime.TimeLogService.Infrastructure.AionTimeContext;
using TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<TunNetComAionTimeTimeLogServiceDataBaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("TimeLogContext"));
            });

            services.AddScoped(typeof(IGeniricRepository<>), typeof(GeniricRepository<>));
            services.AddScoped<IWorkItemTimeLogRepository, WorkItemTimeLogRepository>();
            services.AddScoped<IOrganisationRepository,OrganisationRepository>();

            return services;
        }
    }
}
