using Microsoft.Extensions.DependencyInjection;

namespace TunNetCom.AionTime.SharedKernel;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddRabbitMQ(
        this IServiceCollection services,
        Action<RabbitMQOptions> configure,
        Action<IEventBus>? configureSubscriptions = null)
    {
        RabbitMQOptions options = new()
        {
            EventBusPassword = "AionTime",
            EventBusUserName = "AionTime",
            EventBusConnection = "localhost",
            ServiceName = "Mayservice",
        };
        configure?.Invoke(options);
        _ = services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
        {
            ILogger<DefaultRabbitMQPersistentConnection> logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

            ConnectionFactory factory = new()
            {
                HostName = options.EventBusConnection,
                DispatchConsumersAsync = true,
            };

            if (!string.IsNullOrEmpty(options.EventBusConnection))
            {
                factory.UserName = options.EventBusUserName;
            }

            if (!string.IsNullOrEmpty(options.EventBusPassword))
            {
                factory.Password = options.EventBusPassword;
            }

            return new DefaultRabbitMQPersistentConnection(factory, logger, options.EventBusRetryCount);
        });
        _ = services.AddSingleton<IEventBus, EventBusRabbitMQService>(sp =>
        {
            IRabbitMQPersistentConnection rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
            ILifetimeScope iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            ILogger<EventBusRabbitMQService> logger = sp.GetRequiredService<ILogger<EventBusRabbitMQService>>();
            IEventBusSubscriptionsManager eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            return new EventBusRabbitMQService(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubscriptionsManager, options.ServiceName, options.EventBusRetryCount);
        });

        _ = services.AddSingleton<IEventBus>(sp =>
        {
            IRabbitMQPersistentConnection rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
            ILifetimeScope lifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            ILogger<EventBusRabbitMQService> logger = sp.GetRequiredService<ILogger<EventBusRabbitMQService>>();
            IEventBusSubscriptionsManager eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            EventBusRabbitMQService eventBus = new(
                rabbitMQPersistentConnection,
                logger,
                lifetimeScope,
                eventBusSubscriptionsManager,
                options.ServiceName,
                options.EventBusRetryCount);

            configureSubscriptions?.Invoke(eventBus);

            return eventBus;
        });

        _ = services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        return services;
    }
}