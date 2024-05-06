namespace TunNetCom.AionTime.AzureDevopsService.UnitTest.Helpers;

internal sealed class TestHttpMessageHandlerBuilderFilter(
    IEnumerable<HttpMessageHandlerMockWrapper> httpMessageHandlerWrappers)
        : IHttpMessageHandlerBuilderFilter
{
    private readonly IEnumerable<HttpMessageHandlerMockWrapper> _httpMessageHandlerWrappers = httpMessageHandlerWrappers;

    public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
    {
        return builder =>
        {
            // Checking if a given HttpClient has a registered HttpMessageHandler mock
            HttpMessageHandlerMockWrapper? mockHandlerWrapper = _httpMessageHandlerWrappers
                .SingleOrDefault(x =>
                    x.TypedHttpClientType.Name.Equals(
                        builder.Name,
                        StringComparison.OrdinalIgnoreCase));

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