namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.WorkItem;

public class WorkItemExternalService(HttpClient httpClient, ILogger<WorkItemExternalService> logger) : IWorkItemExternalService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WorkItemExternalService> _logger = logger;

    public async Task<OneOf<WiqlResponses, WiqlBadRequestResponce>> GetWorkItemByUser(WorkItemRequest resource)
    {
        WiqlRequest wiqlRequest = WorkItemHelper.FillGetWorkItemByUser(resource);

        HttpClientHelper.SetAuthHeader(_httpClient, resource.Path);

        using HttpResponseMessage workItemResponse = await _httpClient.PostAsJsonAsync(
            @$"/{wiqlRequest.Organization}/{wiqlRequest.Project}/{wiqlRequest.Team}/_apis/wit/wiql?api-version={wiqlRequest.ApiVersion}",
            wiqlRequest);

        if (workItemResponse.StatusCode == HttpStatusCode.OK)
        {
            WiqlResponses? wiqlResponses = await workItemResponse.Content.ReadFromJsonAsync<WiqlResponses>();
            wiqlResponses!.Email = wiqlRequest.Email;
            wiqlResponses.Path = wiqlRequest.Path;
            return wiqlResponses;
        }

        _logger.LogError(await workItemResponse.Content.ReadAsStringAsync());

        if (workItemResponse.StatusCode == HttpStatusCode.BadRequest)
        {
            WiqlBadRequestResponce wiqlBadResponses = await workItemResponse.Content.ReadFromJsonAsync<WiqlBadRequestResponce>();
            wiqlBadResponses!.Path = wiqlRequest.Path;
            wiqlBadResponses.Email = wiqlRequest.Email;

            return wiqlBadResponses;
        }

        return new WiqlBadRequestResponce()
        {
            Email = resource.Email,
            ErrorCode = (int?)workItemResponse.StatusCode,
            Message = AzureResponseMessage.WorkItemError,
            Path = resource.Path,
        };
    }
}