namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient
{
    public async Task<GetAllProjectsResponse?> GetAll(BaseRequest baseRequest)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(
        new Uri(@$"/{baseRequest.Organization}/_apis/projects?api-version={baseRequest.ApiVersion}"));

        // response.EnsureSuccessStatusCode();
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            GetAllProjectsResponse? wiqlResponses
                = await response.Content.ReadFromJsonAsync<GetAllProjectsResponse>();

            return wiqlResponses;
        }

        return null;
    }
}