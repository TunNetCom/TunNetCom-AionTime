using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams.Contracts;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public partial class AzureDevOpsClient(
    HttpClient httpClient,
    ILogger<AzureDevOpsClient> logger,
    IOptions<CoreServerSettings> coreServerSettings) : IAzureDevOpsClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<AzureDevOpsClient> _logger = logger;
    private readonly CoreServerSettings _coreServerSettings = coreServerSettings.Value;
}