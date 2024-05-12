using TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams.Contracts;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams;

public interface ITeamsClient
{
    Task<TeamResponse?> GetTeamsByProjectAsync(string organizationName, string projectName);
}