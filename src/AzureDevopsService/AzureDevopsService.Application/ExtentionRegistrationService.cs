using TunNetCom.AionTime.SharedKernel;

namespace AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        _ = services.AddRabbitMQ(config =>
        {
            config.EventBusConnection = "RabbitMq";
            config.EventBusUserName = "guest";
            config.EventBusPassword = "guest";
            config.BrokerName = "aion_time_exchange";
            config.EventBusRetryCount = 3;
        });

        services.AddTransient<TenantCreatedIntegrationEventHandler>();

        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
