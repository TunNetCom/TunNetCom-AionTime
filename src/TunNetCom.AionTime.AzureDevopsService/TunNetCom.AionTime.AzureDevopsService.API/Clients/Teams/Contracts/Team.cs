namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams.Contracts;

public class Team
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required Uri Url { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("identityUrl")]
    public required Uri IdentityUrl { get; set; }

    [JsonPropertyName("projectName")]
    public required string ProjectName { get; set; }

    [JsonPropertyName("projectId")]
    public required string ProjectId { get; set; }
}