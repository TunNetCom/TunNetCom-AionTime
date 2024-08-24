namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.WorkItem
{
    public class WorkItemExternalService(HttpClient httpClient, ILogger<WorkItemExternalService> logger) : IWorkItemExternalService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<WorkItemExternalService> _logger = logger;

        public async Task<OneOf<WiqlResponses?, WiqlBadRequestResponce?>> GetWorkItemByUser(WorkItemRequest resource)
        {
            WiqlRequest request = WorkItemHelper.FillGetWorkItemByUser(resource);

            HttpClientHelper.SetAuthHeader(_httpClient, resource.Path);

            using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                @$"/{request.Organization}/{request.Project}/{request.Team}/_apis/wit/wiql?api-version={request.ApiVersion}",
                request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                WiqlResponses? wiqlResponses = await response.Content.ReadFromJsonAsync<WiqlResponses>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                wiqlResponses.Email = request.Email;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                wiqlResponses.Path = request.Path;
                return wiqlResponses;
            }

            string strRes = await response.Content.ReadAsStringAsync();
            _logger.LogError(await response.Content.ReadAsStringAsync());

            WiqlBadRequestResponce? wiqlBadResponses = await response.Content.ReadFromJsonAsync<WiqlBadRequestResponce>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            wiqlBadResponses.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            wiqlBadResponses.Email = request.Email;
            return wiqlBadResponses;
        }
    }
}