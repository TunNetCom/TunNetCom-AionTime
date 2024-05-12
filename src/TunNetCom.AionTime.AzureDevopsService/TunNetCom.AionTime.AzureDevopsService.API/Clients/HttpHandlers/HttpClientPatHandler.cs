namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers;

public class HttpClientPatHandler(
    ILogger<HttpClientPatHandler> logger,
    IPatResolver patResolver,
    IOptions<CoreServerSettings> coreServerSettings)
    : DelegatingHandler
{
    private readonly ILogger<HttpClientPatHandler> _logger = logger;
    private readonly CoreServerSettings _coreServerSettings = coreServerSettings.Value;
    private readonly IPatResolver _patResolver = patResolver;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Uri? uri = request.RequestUri;

        if (uri is null)
        {
            _logger.LogError("Uri not provided.");
            throw new UriNotProvidedException("Uri not provided.");
        }

        string? organizationName = GetOrganizationNameFromRequestUri(uri, _coreServerSettings.DefaultUrl);

        if (string.IsNullOrEmpty(organizationName))
        {
            _logger.LogError("Organization name not provided in the request.");
            throw new OrganizationNotProvidedException("Organization name not provided in the request.");
        }

        string? pat = await _patResolver.GetPatAsync(organizationName);

        if (string.IsNullOrEmpty(pat))
        {
            _logger.LogError($"PAT not found for the organization: {organizationName}");
            throw new PatNotFoundException($"PAT not found for the organization: {organizationName}");
        }

        SetAuthHeader(request, pat);

        return await base.SendAsync(request, cancellationToken);
    }

    private static string GetOrganizationNameFromRequestUri(Uri uri, Uri coreServer)
    {
        string uriString = uri.ToString();

        string pattern = $"{Regex.Escape(coreServer.ToString())}(.*?)/";

        Match match = Regex.Match(uriString, pattern);
        if (match.Success && match.Groups.Count > 1)
        {
            string organizationName = match.Groups[1].Value;
            return organizationName;
        }

        throw new OrganizationNotProvidedException("Cannot get the organization name from the request uri.");
    }

    private static void SetAuthHeader(HttpRequestMessage request, string? pat)
    {
        string basicAuthenticationUsername = "Basic";

        string basicAuthenticationValue = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{pat}"));

        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);
    }
}