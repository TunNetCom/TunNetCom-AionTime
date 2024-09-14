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
                _ = x.AddConsumer<ProjectConsumer>();
                _ = x.AddConsumer<WorkItemConsumer>();
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
                     config.ReceiveEndpoint("ProjectResponce", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<ProjectConsumer>(context);
                     });
                     config.ReceiveEndpoint("WorkItemResponce", e =>
                     {
                         e.SetQueueArgument("x-message-ttl", 60000);
                         e.ConfigureConsumer<WorkItemConsumer>(context);
                     });
                 });
            });

            return services;
        }
    }
}