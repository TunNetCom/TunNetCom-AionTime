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

    public static IServiceCollection AddConsumer(
        this IServiceCollection services,
        Action<ConsumerBuilder> configureConsumers)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));
        if (configureConsumers == null)
            throw new ArgumentNullException(nameof(configureConsumers));

        var builder = new ConsumerBuilder(services);
        configureConsumers(builder);

        return services;
    }

    public static IServiceCollection AddConsumer<T, TH>(this IServiceCollection services)
        where T : IntegrationEvent
        where TH : class, IIntegrationEventHandler<T>
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services.AddTransient<TH>();

        services.AddHostedService(sp =>
        {
            var eventBus = sp.GetRequiredService<IEventBus>();
            eventBus.Subscribe<T, TH>();
            return new EventBusSubscriptionHostedService();
        });

        return services;
    }
}