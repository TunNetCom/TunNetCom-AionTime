namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient
{
    public async Task<GetAllProjectsResponse?> GetAll(BaseRequest baseRequest)
    {
        var response = await _httpClient.GetAsync(
        @$"/{baseRequest.Organization}/_apis/projects?api-version={baseRequest.ApiVersion}");

        response.EnsureSuccessStatusCode();

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var wiqlResponses = await response.Content.ReadFromJsonAsync<GetAllProjectsResponse>();

            return wiqlResponses;
        }

        return null;
    }
}