using AzureDevopsService.Contracts.Internal.Interfaces;
using AzureDevopsService.Contracts.Settings;
using Microsoft.Extensions.Configuration;

namespace AzureDevopsService.Infrasructure
{
    public static class ExtentionRegistrationService
    {
        public static IServiceCollection AddInfrasructureService(this IServiceCollection services, IConfiguration configuration)
        {
            AzureDevopsSettings azureDevopsSettings = new();
            configuration.GetSection("AzureDevopsSettings").Bind(azureDevopsSettings);

            _ = services.AddHttpClient<IUserProfileApiClient, UserProfileApiClient>((serviceProvider, client) =>
            {
                client.BaseAddress = azureDevopsSettings.BaseUrlVssps;
            });

            _ = services.AddHttpClient<IWorkItemExternalService, WorkItemExternalService>((serviceProvider, client) =>
            {
                client.BaseAddress = azureDevopsSettings.BaseUrlAzure;
            });

            _ = services.AddHttpClient<IProjectService, ProjectService>((serviceProvider, client) =>
            {
                client.BaseAddress = azureDevopsSettings.BaseUrlAzure;
            });

            _ = services.AddHttpClient<IWebhookService, WebhookService>((serviceProvider, client) =>
            {
                client.BaseAddress = azureDevopsSettings.BaseUrlAzure;
            });

            return services;
        }
    }
}