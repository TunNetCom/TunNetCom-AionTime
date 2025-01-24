namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.HooksService;

public class WebhookService(HttpClient httpClient, ILogger<WebhookService> logger) : IWebhookService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WebhookService> _logger = logger;

    public async Task<OneOf<WebhookResponce, WebhookBadRequestResponce>> CreateWebhookSubscription(ServiceHookRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage webhookResponce = await _httpClient.PostAsJsonAsync($"{request.OrganizationName}/_apis/hooks/subscriptions?api-version=7.1-preview.1", request);
        if (webhookResponce.IsSuccessStatusCode)
        {
            return await webhookResponce.Content.ReadFromJsonAsync<WebhookResponce>();
        }
        else
        {
            _logger.LogError($"fail to create webhook for user {request.Email}");
            return await webhookResponce.Content.ReadFromJsonAsync<WebhookBadRequestResponce>();
        }
    }
}