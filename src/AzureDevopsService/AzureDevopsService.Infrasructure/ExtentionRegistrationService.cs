using AzureDevopsService.Contracts.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using static System.Formats.Asn1.AsnWriter;

namespace AzureDevopsService.Infrasructure
{
    public static class ExtentionRegistrationService
    {
        public static IServiceCollection AddInfrasructureService(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.Configure<AzureDevopsSettings>(configuration.GetSection("AzureDevopsSettings"));

            _ = services.AddHttpClient<IUserProfileApiClient, UserProfileApiClient>((serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<AzureDevopsSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrlVssps);
            });

            _ = services.AddHttpClient<IWorkItemExternalService, WorkItemExternalService>((serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<AzureDevopsSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrlAzure);
            });

            _ = services.AddHttpClient<IProjectService, ProjectService>((serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<AzureDevopsSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrlAzure);
            });

            _ = services.AddHttpClient<IWebhookService, WebhookService>((serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<AzureDevopsSettings>>().Value;
                client.BaseAddress = new Uri(settings.BaseUrlAzure);
            });

            return services;
        }
    }
}