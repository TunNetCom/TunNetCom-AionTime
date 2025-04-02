using TimeLogService.Application.Events.IntegrationEvents;
using TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.AzureDevopsIntegrationEvent;
using TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.WebhookIntegrationEvent;

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
                _ = x.AddConsumer<WorkItemEvents>();
                _ = x.AddConsumer<PipelineEvents>();
                _ = x.AddConsumer<BuildAndReleasEvents>();
                _ = x.AddConsumer<CodeEvents>();
                _ = x.AddConsumer<ProfileUserEvents>();
                _ = x.AddConsumer<ProjectEvents>();
                _ = x.AddConsumer<WorkItemEvent>();

                x.SetDefaultEndpointNameFormatter();
                x.UsingRabbitMq((context, config) =>
                 {
                     RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                     config.Host(rabbitMqSettings.ServiceName, "/", h =>
                      {
                          h.Username(rabbitMqSettings.UserName);
                          h.Password(rabbitMqSettings.Password);
                      });

                     config.UseNewtonsoftJsonSerializer();

                     config.ReceiveEndpoint("WorkItemEvent", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<WorkItemEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("PipelineEvent", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<PipelineEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("BuildAndReleaseEvents", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<BuildAndReleasEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("CodeEvents", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<CodeEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("timelog-service-queue", e =>
                     {
                         e.ConfigureConsumer<ProfileUserEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("ProjectResponce", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<ProjectEvents>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                     config.ReceiveEndpoint("WorkItemResponce", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<WorkItemEvent>(context);
                         e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                     });
                 });
            });

            return services;
        }
    }
}