using Microsoft.Extensions.Configuration;
using static MassTransit.Logging.DiagnosticHeaders.Messaging;

namespace AzureDevopsWebhookService.Application;

public static class AzureWebhookServiceRegistration
{
    public static IServiceCollection AddAzureWebhookServiceRegistration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        _ = services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration.GetSection("RabbitMqSettings")["ServiceName"], "/", h =>
                {
                    h.Username(configuration.GetSection("RabbitMqSettings")["UserName"]!);
                    h.Password(configuration.GetSection("RabbitMqSettings")["PassWord"]!);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}