namespace WebhookService.Application;

public static class AzureWebhookServiceRegistration
{
    public static IServiceCollection AddAzureWebhookServiceRegistration(
        this IServiceCollection services)
    {
        
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}