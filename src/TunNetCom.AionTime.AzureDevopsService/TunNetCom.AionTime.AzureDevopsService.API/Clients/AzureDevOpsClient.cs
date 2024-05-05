namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient : IAzureDevOpsClient
{
    private readonly HttpClient httpClient;
    private readonly ILogger<AzureDevOpsClient> logger;

    public AzureDevOpsClient(
        HttpClient httpClient,
        ILogger<AzureDevOpsClient> logger)
    {
        this.httpClient = httpClient;
        this.logger = logger;
    }
}
