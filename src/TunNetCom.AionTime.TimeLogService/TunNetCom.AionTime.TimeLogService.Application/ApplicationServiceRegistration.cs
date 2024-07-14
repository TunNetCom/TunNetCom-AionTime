using AzureDevopsWebhookService.Contracts.Settings;
using MassTransit;
using Microsoft.Extensions.Options;
using TunNetCom.AionTime.TimeLogService.Application.Feature.RabbitMqConsumer.WebhookConsumer;
using TunNetCom.AionTime.TimeLogService.Contracts.Settings;
using static MassTransit.Logging.OperationName;
using static Org.BouncyCastle.Math.EC.ECCurve;
using RabbitMqSettings = TunNetCom.AionTime.TimeLogService.Contracts.Settings.RabbitMqSettings;

namespace TunNetCom.AionTime.TimeLogService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            _ = services.AddAutoMapper(Assembly.GetExecutingAssembly());

            _ = services.AddMassTransit(x =>
            {
                _ = x.AddConsumer<WorkItemEventConsumer>();
                _ = x.AddConsumer<PipelineEventConsumer>();
                _ = x.AddConsumer<BuildAndReleasEventsConsumer>();
                _ = x.AddConsumer<CodeEventsConsumer>();
                x.SetDefaultEndpointNameFormatter();
                x.UsingRabbitMq((context, config) =>
                 {
                     RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                     config.Host(rabbitMqSettings.ServiceName, "/", h =>
                      {
                          h.Username(rabbitMqSettings.UserName);
                          h.Password(rabbitMqSettings.Password);
                      });
                     config.ReceiveEndpoint("WorkItemEvent", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<WorkItemEventConsumer>(context);
                     });
                     config.ReceiveEndpoint("PipelineEvent", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<PipelineEventConsumer>(context);
                     });
                     config.ReceiveEndpoint("BuildAndReleaseEvents", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<BuildAndReleasEventsConsumer>(context);
                     });
                     config.ReceiveEndpoint("CodeEvents", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<CodeEventsConsumer>(context);
                     });
                 });
            });

            return services;
        }
    }
}