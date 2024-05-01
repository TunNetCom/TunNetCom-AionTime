using System.Text.Json.Serialization;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects.Contracts;

public class GetAllProjectsResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("value")]
    public IEnumerable<ProjectInfo> ProjectInfos { get; set; } = Enumerable.Empty<ProjectInfo>();

}

public class ProjectInfo
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("revision")]
    public int Revision { get; set; }

    [JsonPropertyName("visibility")]
    public string Visibility { get; set; } = string.Empty;

    [JsonPropertyName("lastUpdateTime")]
    public DateTime LastUpdateTime { get; set; }
}