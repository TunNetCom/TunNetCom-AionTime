namespace TunNetCom.AionTime.AzureDevopsService.UnitTest.Helpers;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection OverridePrimaryHttpMessageHandler<TClient>(
        this IServiceCollection services,
        HttpMessageHandler mockMessageHandler)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (mockMessageHandler == null)
        {
            throw new ArgumentNullException(nameof(mockMessageHandler));
        }

        // Register a mock handler
        services
            .AddTransient(_ => new HttpMessageHandlerMockWrapper(typeof(TClient), mockMessageHandler));

        // Replace the default or already registered IHttpMessageHandlerBuilderFilter
        // with our TestHttpMessageHandlerBuilderFilter
        services
            .Replace(
                ServiceDescriptor
                    .Transient<IHttpMessageHandlerBuilderFilter, TestHttpMessageHandlerBuilderFilter>());

        return services;
    }
}