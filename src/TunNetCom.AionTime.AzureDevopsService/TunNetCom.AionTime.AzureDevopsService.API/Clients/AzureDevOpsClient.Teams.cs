namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient
{
    public async Task<TeamResponse?> GetTeamsByProjectAsync(string organizationName, string projectName)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(
        new Uri(
            $"/{organizationName}/_apis/projects/{projectName}/teams?$mine=false&api-version={_coreServerSettings.ApiVersion}",
            UriKind.Relative));

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        if (response.StatusCode == HttpStatusCode.OK)
        {
            TeamResponse? teamResponse
                = await response.Content.ReadFromJsonAsync<TeamResponse>();

            return teamResponse;
        }

        return null;
    }
}