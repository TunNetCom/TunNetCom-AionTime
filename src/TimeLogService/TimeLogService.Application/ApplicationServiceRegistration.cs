using TimeLogService.Application.Events.IntegrationEvents.EventsHandlers;
using TunNetCom.AionTime.SharedKernel;

namespace TimeLogService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());

            _ = services.AddRabbitMQ(
                config =>
                {
                    config.EventBusConnection = "localhost";
                    config.EventBusUserName = "AionTime";
                    config.EventBusPassword = "AionTime";
                    config.ServiceName = "timelog_service";
                    config.EventBusRetryCount = 5;
                },
                eventBus =>
                {
                    eventBus.Subscribe<TenantOrganizationProjectsRetrivedIntegrationEvent, TenantOrganizationProjectsRetrivedIntegrationEventHandler>();
                });

            return services;
        }
    }
}