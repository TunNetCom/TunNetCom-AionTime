namespace AzureDevopsService.Contracts.AzureResponceModel;

public class UserProfile : BaseRequest
{
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("publicAlias")]
    public string PublicAlias { get; set; } = string.Empty;

    [JsonProperty("emailAddress")]
    public string EmailAddress { get; set; } = string.Empty;

    [JsonProperty("coreRevision")]
    public int CoreRevision { get; set; }

    [JsonProperty("timeStamp")]
    public DateTime TimeStamp { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("revision")]
    public int Revision { get; set; }

    [JsonProperty("UserAccount")]
    public UserAccount? UserAccount { get; set; };
}