using TunNetCom.AionTime.SharedKernel;

namespace TimeLogService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());

        _ = services.AddRabbitMQ(config =>
        {
            config.EventBusConnection = "localhost";
            config.EventBusUserName = "guest";
            config.EventBusPassword = "guest";
            config.BrokerName = "timelog_service";
            config.EventBusRetryCount = 3;
        });

        return services;
    }
}