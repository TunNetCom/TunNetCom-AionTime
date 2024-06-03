using TunNetCom.AionTime.AzureDevopsService.API.Data;

namespace TunNetCom.AionTime.AzureDevopsService.API;

public class PatResolver(
    ILogger<PatResolver> logger,
    AzureDevOpsContext azureDevOpsContext) : IPatResolver
{
    private readonly ILogger<PatResolver> _logger = logger;
    private readonly AzureDevOpsContext _azureDevOpsContext = azureDevOpsContext;

    public async Task<string?> GetPatAsync(string organizationName)
    {
        _logger.LogInformation("Try to get the PAT of the organization {Organization}", organizationName);

        Organization? organization = await _azureDevOpsContext.Organizations
            .FirstOrDefaultAsync(org => org.Name == organizationName);

        return organization?.Pat;
    }
}