namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects.Contracts;

public class GetAllProjectsResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("value")]
    public IEnumerable<ProjectInfo> ProjectInfos { get; set; } = Enumerable.Empty<ProjectInfo>();
}