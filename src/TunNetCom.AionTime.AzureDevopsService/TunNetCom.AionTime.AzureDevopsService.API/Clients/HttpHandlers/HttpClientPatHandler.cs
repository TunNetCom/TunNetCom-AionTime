using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers
{
    public class HttpClientPatHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestBody = await request.Content.ReadAsStringAsync();
            var baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestBody);

            var organizationName = baseRequest?.Organization;

            if (string.IsNullOrEmpty(organizationName))
            {
                throw new ArgumentException("Password not provided in the request body");
            }

            var basicAuthenticationUsername = "Basic";
            // TODO get the PAT from this DB by organisation name
            var basicAuthenticationPassword = "";
            var basicAuthenticationValue = Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
