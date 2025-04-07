using AzureDevopsService.Application.Events.IntegrationEvents.EventsHandlers;
using TunNetCom.AionTime.SharedKernel;

namespace AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        _ = services.AddRabbitMQ(
            config =>
            {
                config.EventBusConnection = "localhost";
                config.EventBusUserName = "AionTime";
                config.EventBusPassword = "AionTime";
                config.ServiceName = "azure_devops_service";
                config.EventBusRetryCount = 5;
            },
            eventBus =>
            {
                eventBus.Subscribe<TenantCreatedIntegrationEvent, TenantCreatedIntegrationEventHandler>();
            });

        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}