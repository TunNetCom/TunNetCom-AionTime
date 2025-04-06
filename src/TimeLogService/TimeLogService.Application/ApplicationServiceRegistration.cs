using TimeLogService.Application.Events.IntegrationEvents;
using TimeLogService.Application.Events.IntegrationEvents.EventsHandlers;

namespace TimeLogService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}