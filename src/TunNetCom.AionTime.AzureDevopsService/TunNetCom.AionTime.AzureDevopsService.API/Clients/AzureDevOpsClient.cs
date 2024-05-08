namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient(
    HttpClient httpClient,
    ILogger<AzureDevOpsClient> logger) : IAzureDevOpsClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<AzureDevOpsClient> _logger = logger;
}