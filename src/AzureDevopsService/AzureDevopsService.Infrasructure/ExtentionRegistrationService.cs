namespace AzureDevopsService.Infrasructure
{
    public static class ExtentionRegistrationService
    {
        public static IServiceCollection AddInfrasructureService(this IServiceCollection services)
        {
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

            _ = services.AddHttpClient<IWebhookService, WebhookService>(x =>
            {
                x.BaseAddress = new Uri("https://dev.azure.com");
            });
            return services;
        }
    }
}