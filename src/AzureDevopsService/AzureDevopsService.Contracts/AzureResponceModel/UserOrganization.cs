namespace AzureDevopsService.Contracts.AzureResponceModel;

public class UserOrganization
{
    [JsonProperty("accountId")]
    public string AccountId { get; set; } = string.Empty;

    [JsonProperty("accountUri")]
    public Uri? AccountUri { get; set; };

    [JsonProperty("accountName")]
    public string AccountName { get; set; } = string.Empty;
}