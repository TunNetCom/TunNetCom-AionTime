namespace AzureDevopsWebhookService.Application;

public static class AzureWebhookServiceRegistration
{
    public static IServiceCollection AddAzureWebhookServiceRegistration(this IServiceCollection services)
    {
        _ = services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}