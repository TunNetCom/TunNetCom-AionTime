namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers;

using System.Net.Http.Headers;
using Newtonsoft.Json;

public class HttpClientPatHandler(ILogger<HttpClientPatHandler> logger)
    : DelegatingHandler
{
    private ILogger<HttpClientPatHandler> logger = logger;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestBody = await request.Content.ReadAsStringAsync();
        var baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestBody);

        var organizationName = baseRequest?.Organization;

        if (string.IsNullOrEmpty(organizationName))
        {
            this.logger.LogError("Password not provided in the request body");
            throw new ArgumentException("Password not provided in the request body");
        }

        var basicAuthenticationUsername = "Basic";

        // TODO get the PAT from this DB by organisation name
        var basicAuthenticationPassword = string.Empty;
        var basicAuthenticationValue = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);

        return await base.SendAsync(request, cancellationToken);
    }
}
