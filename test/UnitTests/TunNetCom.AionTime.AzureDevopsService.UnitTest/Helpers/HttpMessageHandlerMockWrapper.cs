namespace TunNetCom.AionTime.AzureDevopsService.UnitTest.Helpers;

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