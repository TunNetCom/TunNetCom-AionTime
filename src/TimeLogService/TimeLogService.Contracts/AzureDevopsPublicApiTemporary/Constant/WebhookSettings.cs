namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.Constant;

public static class WebhookSettings
{
    public const string BaseUrl = "https://your-public-api.com/{0}?organizationId={1}&TenantId={2}";
    public const string HttpHeaders = "{\"Content-Type\": \"application/json\"}";
    public const string ResourceDetailsToSend = "all";
    public const string PublisherId = "tfs";
    public const string ConsumerId = "webHooks";
    public const string ConsumerActionId = "httpRequest";
}