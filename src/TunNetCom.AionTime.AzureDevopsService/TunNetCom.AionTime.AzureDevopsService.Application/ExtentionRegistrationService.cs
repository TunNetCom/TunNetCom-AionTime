using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.OrganizationProjectService;

namespace TunNetCom.AionTime.AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        // TODO move base adress to settings area
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