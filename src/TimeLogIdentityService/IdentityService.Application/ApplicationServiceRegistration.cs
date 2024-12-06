#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using IdentityService.Application.Features.MessageBroker.Consumer;
using IdentityService.Contracts.Settings;
using MassTransit;
using Microsoft.Extensions.Options;

namespace IdentityService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        _ = services.AddMassTransit(x =>
        {
            x.SetDefaultEndpointNameFormatter();
            _ = x.AddConsumer<AzureDevopsConsumer>();
            x.SetDefaultEndpointNameFormatter();

            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                cfg.Host(rabbitMqSettings.ServiceName, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });

                cfg.UseNewtonsoftJsonSerializer();

                cfg.ReceiveEndpoint("ProfileUserResponce", e =>
                {
                    e.SetQueueArgument("x-message-ttl", 60000);
                    e.ConfigureConsumer<AzureDevopsConsumer>(context);
                });
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}