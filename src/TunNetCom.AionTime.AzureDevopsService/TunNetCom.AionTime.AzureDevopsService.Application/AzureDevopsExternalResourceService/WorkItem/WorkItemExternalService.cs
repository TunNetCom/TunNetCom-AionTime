using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ServiceHelper.WorkItem;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.WorkItem;

public class WorkItemExternalService(HttpClient httpClient, ILogger<WorkItemExternalService> logger) : IWorkItemExternalService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WorkItemExternalService> _logger = logger;

    public async Task<OneOf<WiqlResponses?, WiqlBadRequestResponce?>> GetWorkItemByUser(WorkItemRequest resource)
    {
        WiqlRequest wiqlRequest = WorkItemHelper.FillGetWorkItemByUser(resource);

        HttpClientHelper.SetAuthHeader(_httpClient, resource.Path);

        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            @$"/{wiqlRequest.Organization}/{wiqlRequest.Project}/{wiqlRequest.Team}/_apis/wit/wiql?api-version={wiqlRequest.ApiVersion}",
            wiqlRequest);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            WiqlResponses? wiqlResponses = await response.Content.ReadFromJsonAsync<WiqlResponses>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            wiqlResponses.Email = wiqlRequest.Email;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            wiqlResponses.Path = wiqlRequest.Path;
            return wiqlResponses;
        }

        _logger.LogError(await response.Content.ReadAsStringAsync());

        WiqlBadRequestResponce? wiqlBadResponses = await response.Content.ReadFromJsonAsync<WiqlBadRequestResponce>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        wiqlBadResponses.Path = wiqlRequest.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        wiqlBadResponses.Email = wiqlRequest.Email;
        return wiqlBadResponses;
    }
}