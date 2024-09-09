using TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.ProfileUser;
using TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WebhookConsumer;

namespace TimeLogService.Application
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
                _ = x.AddConsumer<ProfileUserConsumer>();
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
                     config.ReceiveEndpoint("ProfileUserResponce", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<ProfileUserConsumer>(context);
                     });
                 });
            });

            return services;
        }
    }
}