using IdentityService.Application.Events.DomainEvents.EventsHandlers;
using TunNetCom.AionTime.SharedKernel;

namespace IdentityService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        _ = services.AddRabbitMQ(
            config =>
            {
                config.EventBusConnection = "RabbitMq";
                config.EventBusUserName = "guest";
                config.EventBusPassword = "guest";
                config.BrokerName = "aion_time_exchange";
                config.EventBusRetryCount = 5;
            });

        services.AddTransient<TenantCreatedDomainEventHandler>();
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}