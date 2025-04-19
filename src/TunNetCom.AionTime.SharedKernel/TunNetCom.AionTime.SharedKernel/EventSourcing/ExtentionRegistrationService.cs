using TunNetCom.AionTime.SharedKernel.EventSourcing.EventBusRabbitMQ.Extensions;

namespace TunNetCom.AionTime.SharedKernel;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddRabbitMQ(
        this IServiceCollection services,
        Action<RabbitMQOptions> configure)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configure == null)
            throw new ArgumentNullException(nameof(configure));

        var config = new RabbitMQOptions();
        configure(config);

        services.AddSingleton(config);
        services.AddSingleton<IRabbitMQConnectionManager, RabbitMQConnectionManager>();
        services.AddSingleton<IEventBus, RabbitMQEventBus>();

        return services;
    }
}