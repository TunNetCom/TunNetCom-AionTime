namespace AzureDevopsService.Contracts.SharedModel;

public class Links
{
    [JsonProperty("self")]
    public required Link Self { get; set; }

    [JsonProperty("consumer")]
    public required Link Consumer { get; set; }

    [JsonProperty("actions")]
    public required Link Actions { get; set; }

    [JsonProperty("notifications")]
    public required Link Notifications { get; set; }

    [JsonProperty("publisher")]
    public required Link Publisher { get; set; }
}