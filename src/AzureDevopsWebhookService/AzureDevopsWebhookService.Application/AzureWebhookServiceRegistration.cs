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
            x.SetDefaultEndpointNameFormatter();
            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                cfg.Host(rabbitMqSettings.ServiceName, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });
                cfg.ConfigureEndpoints(context, new DefaultEndpointNameFormatter("dev", false));
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}