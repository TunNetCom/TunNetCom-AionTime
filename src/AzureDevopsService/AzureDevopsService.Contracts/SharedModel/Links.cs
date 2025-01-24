namespace AzureDevopsService.Contracts.SharedModel;

public class Links
{
    [JsonProperty("self")]
    public Link Self { get; set; }

    [JsonProperty("consumer")]
    public Link Consumer { get; set; }

    [JsonProperty("actions")]
    public Link Actions { get; set; }

    [JsonProperty("notifications")]
    public Link Notifications { get; set; }

    [JsonProperty("publisher")]
    public Link Publisher { get; set; }
}