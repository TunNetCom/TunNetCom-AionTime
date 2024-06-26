using AzureDevopsWebhookService.Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static MassTransit.Logging.DiagnosticHeaders.Messaging;

namespace AzureDevopsWebhookService.Application;

public static class AzureWebhookServiceRegistration
{
    public static IServiceCollection AddAzureWebhookServiceRegistration(
        this IServiceCollection services)
    {
        _ = services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                cfg.Host(rabbitMqSettings.ServiceName, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.ServiceName);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}