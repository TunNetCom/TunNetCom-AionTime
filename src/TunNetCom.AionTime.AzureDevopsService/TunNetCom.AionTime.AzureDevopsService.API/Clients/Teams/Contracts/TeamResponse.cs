namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams.Contracts;

public class TeamResponse
{
    [JsonPropertyName("value")]
    public IEnumerable<Team> TeamList { get; set; } = Enumerable.Empty<Team>();

    [JsonPropertyName("count")]
    public required int Count { get; set; }
}