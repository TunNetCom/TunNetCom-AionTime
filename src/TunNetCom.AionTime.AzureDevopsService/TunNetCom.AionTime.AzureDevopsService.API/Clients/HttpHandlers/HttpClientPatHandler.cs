namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers;

public class HttpClientPatHandler(
    ILogger<HttpClientPatHandler> logger)
    : DelegatingHandler
{
    private readonly ILogger<HttpClientPatHandler> _logger = logger;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        string requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
        BaseRequest? baseRequest = JsonConvert.DeserializeObject<BaseRequest>(requestBody);

        string? organizationName = baseRequest?.Organization;

        if (string.IsNullOrEmpty(organizationName))
        {
            _logger.LogError("Password not provided in the request body");
            throw new ArgumentException("Password not provided in the request body");
        }

        // TODO get the PAT from this DB by organisation name
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<IAzureDevOpsClient>()
            .Build();

        string? basicAuthenticationPassword = config["tmp_pat:default"];

        string basicAuthenticationUsername = "Basic";

        string basicAuthenticationValue = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);

        return await base.SendAsync(request, cancellationToken);
    }
}