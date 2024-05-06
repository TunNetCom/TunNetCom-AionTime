namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public static class ClientRegistration
{
    public static IServiceCollection AddAzureDevOpsClients(this IServiceCollection services)
    {
        _ = services.AddTransient<HttpClientPatHandler>();

        _ = services.AddHttpClient<IAzureDevOpsClient, AzureDevOpsClient>((serviceProvider, client) =>
        {
            client.DefaultRequestHeaders.Clear();

            string coreServer = "dev.azure.com";

            client.BaseAddress = new Uri($"https://{coreServer}");
        })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
            .AddHttpMessageHandler<HttpClientPatHandler>();

        return services;
    }
}