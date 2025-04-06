namespace AzureDevopsService.Contracts.AzureResponceModel;

public class ProjectResponce
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("url")]
    public Uri? Url { get; set; }

    [JsonProperty("state")]
    public string State { get; set; } = string.Empty;

    [JsonProperty("revision")]
    public int Revision { get; set; }

    [JsonProperty("visibility")]
    public string Visibility { get; set; } = string.Empty;

    [JsonProperty("lastUpdateTime")]
    public DateTime LastUpdateTime { get; set; }
}