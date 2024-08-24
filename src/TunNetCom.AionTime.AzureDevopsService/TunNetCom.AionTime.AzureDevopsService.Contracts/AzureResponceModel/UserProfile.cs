using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Contracts;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

public class UserProfile : BaseRequest
{
    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }

    [JsonProperty("publicAlias")]
    public string? PublicAlias { get; set; }

    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonProperty("coreRevision")]
    public int CoreRevision { get; set; }

    [JsonProperty("timeStamp")]
    public DateTime TimeStamp { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("revision")]
    public int Revision { get; set; }
}