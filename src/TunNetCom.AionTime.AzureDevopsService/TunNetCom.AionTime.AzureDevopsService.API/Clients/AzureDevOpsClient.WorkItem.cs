namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient
{
    public async Task<OneOf<WiqlResponses?, WiqlBadRequest?>> GetWiqlResponses(WiqlRequest wiqlRequest)
    {
        _logger.LogInformation("Get Work Item for {Organisation}", wiqlRequest.Organization);

        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
        @$"/{wiqlRequest.Organization}/{wiqlRequest.Project}/{wiqlRequest.Team}/_apis/wit/wiql?api-version={wiqlRequest.ApiVersion}",
        wiqlRequest);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            var wiqlResponses = await response.Content.ReadFromJsonAsync<WiqlResponses>();

            return wiqlResponses;
        }

        var wiqlBadResponses = await response.Content.ReadFromJsonAsync<WiqlBadRequest>();

        return wiqlBadResponses;
    }
}