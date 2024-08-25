using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Contracts;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

public class UserOrganization
{
    [JsonProperty("accountId")]
    public string? AccountId { get; set; }

    [JsonProperty("accountUri")]
    public Uri? AccountUri { get; set; }

    [JsonProperty("accountName")]
    public string? AccountName { get; set; }
}