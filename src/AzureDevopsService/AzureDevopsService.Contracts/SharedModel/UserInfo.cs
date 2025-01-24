namespace AzureDevopsService.Contracts.SharedModel;

public class UserInfo
{
    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("uniqueName")]
    public string UniqueName { get; set; }

    [JsonProperty("descriptor")]
    public string Descriptor { get; set; }
}