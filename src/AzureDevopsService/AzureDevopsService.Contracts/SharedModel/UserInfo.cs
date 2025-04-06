namespace AzureDevopsService.Contracts.SharedModel;

public class UserInfo
{
    [JsonProperty("displayName")]
    public required string DisplayName { get; set; }

    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("uniqueName")]
    public required string UniqueName { get; set; }

    [JsonProperty("descriptor")]
    public required string Descriptor { get; set; }
}