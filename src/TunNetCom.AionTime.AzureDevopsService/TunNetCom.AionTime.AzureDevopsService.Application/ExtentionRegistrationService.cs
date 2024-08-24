using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProjectService;

namespace TunNetCom.AionTime.AzureDevopsService.Application;

public static class ExtentionRegistrationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        _ = services.AddHttpClient();

        _ = services.AddHttpClient<IProfileUser, ProfileUser>(x =>
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