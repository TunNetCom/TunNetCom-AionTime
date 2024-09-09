using AzureDevopsService.Application.Featurs.MessageBroker.Consumer;

namespace AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        // TODO move base adress to settings area
        _ = services.AddMassTransit(x =>
        {
            x.SetDefaultEndpointNameFormatter();
            _ = x.AddConsumer<ProfileUserConsumer>();
            x.SetDefaultEndpointNameFormatter();

            x.UsingRabbitMq((context, cfg) =>
            {
                RabbitMqSettings rabbitMqSettings = context.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

                cfg.Host(rabbitMqSettings.ServiceName, "/", h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });

                cfg.ReceiveEndpoint("ProfileUser", e =>
                {
                    e.SetQueueArgument("x-message-ttl", 60000);
                    e.ConfigureConsumer<ProfileUserConsumer>(context);
                });
            });
        });
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        _ = services.AddHttpClient();

        _ = services.AddHttpClient<IUserProfileApiClient, UserProfileApiClient>(x =>
        {
            x.BaseAddress = new Uri("https://app.vssps.visualstudio.com");
        });

        _ = services.AddHttpClient<IWorkItemExternalService, WorkItemExternalService>(x =>
        {
            x.BaseAddress = new Uri("https://dev.azure.com");
        });

        _ = services.AddHttpClient<IProjectService, ProjectService>(x =>
        {
            x.BaseAddress = new Uri("https://dev.azure.com");
        });
        return services;
    }
}