namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers;

public class HttpClientPatHandler(
    ILogger<HttpClientPatHandler> logger)
    : DelegatingHandler
{
    private ILogger<HttpClientPatHandler> _logger = logger;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
        var baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestBody);

        var organizationName = baseRequest?.Organization;

        if (string.IsNullOrEmpty(organizationName))
        {
            _logger.LogError("Password not provided in the request body");
            throw new ArgumentException("Password not provided in the request body");
        }

        // TODO get the PAT from this DB by organisation name
        var config = new ConfigurationBuilder()
            .AddUserSecrets<IAzureDevOpsClient>()
            .Build();

        var basicAuthenticationPassword = config["tmp_pat:default"];

        var basicAuthenticationUsername = "Basic";

        var basicAuthenticationValue = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);

        return await base.SendAsync(request, cancellationToken);
    }
}