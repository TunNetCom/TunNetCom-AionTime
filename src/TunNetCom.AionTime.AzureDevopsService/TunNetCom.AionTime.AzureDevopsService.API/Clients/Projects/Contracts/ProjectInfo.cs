namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects.Contracts;

public class ProjectInfo
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("url")]
#pragma warning disable CA1056 // URI-like properties should not be strings
    public string Url { get; set; } = string.Empty;
#pragma warning restore CA1056 // URI-like properties should not be strings

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("revision")]
    public int Revision { get; set; }

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; } = string.Empty;

    [JsonPropertyName("lastUpdateTime")]
    public DateTime LastUpdateTime { get; set; }
}