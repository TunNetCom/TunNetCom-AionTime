using TunNetCom.AionTime.AzureDevopsService.API.Clients.Teams;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public interface IAzureDevOpsClient :
    IProjectClient,
    IWorkItemClient,
    ITeamsClient
{
}