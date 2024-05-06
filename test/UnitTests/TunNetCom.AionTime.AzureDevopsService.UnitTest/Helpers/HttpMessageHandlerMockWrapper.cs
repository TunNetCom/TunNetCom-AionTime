namespace TunNetCom.AionTime.AzureDevopsService.UnitTest.Helpers;

internal sealed class HttpMessageHandlerMockWrapper(
    Type typedHttpClientType,
    HttpMessageHandler httpMessageHandlerMock)
{
    public Type TypedHttpClientType { get; } = typedHttpClientType;

    public HttpMessageHandler HttpMessageHandlerMock { get; } = httpMessageHandlerMock;
}