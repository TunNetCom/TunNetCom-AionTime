namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient : IAzureDevOpsClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AzureDevOpsClient> _logger;

    public AzureDevOpsClient(
        HttpClient httpClient,
        ILogger<AzureDevOpsClient> logger)
    {
        this._httpClient = httpClient;
        _logger = logger;
    }
}
