namespace TunNetCom.AionTime.AzureDevopsService.UnitTest;

public class WorkItemsUnitTest
{

    [Fact]
    public async Task GetWorkItemsTest()
    {
        var serviceProvider = new ServiceCollection()
            .AddAzureDevOpsClients()
            .BuildServiceProvider();

        var sut = serviceProvider.GetRequiredService<IAzureDevOpsClient>();

        WiqlRequest wiqlRequest = new WiqlRequest
        {
            ApiVersion = "v5",
            Organization = "TunNetCom",
            Project = "Aion_Time",
            Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
            Query = @"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath] 
                      FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> ''"
        };

        var result = await sut.GetWiqlResponses(wiqlRequest);

        result.Should().NotBeNull();

        result.AsT0.Should().NotBeNull();

        result.AsT0.WorkItems.Should()
            .NotBeNull();

        result.AsT0.WorkItems.Count.Should().BePositive();
    }
}

internal sealed class TestHttpMessageHandlerBuilderFilter
    : IHttpMessageHandlerBuilderFilter
{
    private readonly IEnumerable<HttpMessageHandlerMockWrapper> _httpMessageHandlerWrappers;

    public TestHttpMessageHandlerBuilderFilter(
        // Injection of previously registered maps
        IEnumerable<HttpMessageHandlerMockWrapper> httpMessageHandlerWrappers)

    {
        _httpMessageHandlerWrappers = httpMessageHandlerWrappers;
    }

    public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
    {
        return builder =>
        {
            // Checking if a given HttpClient has a registered HttpMessageHandler mock
            var mockHandlerWrapper = _httpMessageHandlerWrappers
                .SingleOrDefault(x =>
                    x.TypedHttpClientType.Name.Equals(
                        builder.Name,
                        StringComparison.InvariantCultureIgnoreCase));

            if (mockHandlerWrapper is not null)
            {
                // If so, the default handler is replaced with mock
                Debug.WriteLine($"Overriding {nameof(builder.PrimaryHandler)} for '{builder.Name}' typed HTTP client");
                builder.PrimaryHandler = mockHandlerWrapper.HttpMessageHandlerMock;
            }
            next(builder);
        };
    }
}

internal sealed class HttpMessageHandlerMockWrapper
{
    public HttpMessageHandlerMockWrapper(
        Type typedHttpClientType,
        HttpMessageHandler httpMessageHandlerMock)
    {
        TypedHttpClientType = typedHttpClientType;
        HttpMessageHandlerMock = httpMessageHandlerMock;
    }

    public Type TypedHttpClientType { get; }
    public HttpMessageHandler HttpMessageHandlerMock { get; }
}

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection OverridePrimaryHttpMessageHandler<TClient>(
        this IServiceCollection services,
        HttpMessageHandler mockMessageHandler)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        if (mockMessageHandler == null) throw new ArgumentNullException(nameof(mockMessageHandler));

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