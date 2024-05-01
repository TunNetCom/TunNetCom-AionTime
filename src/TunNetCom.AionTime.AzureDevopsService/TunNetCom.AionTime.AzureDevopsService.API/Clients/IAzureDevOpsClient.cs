using TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects;
using TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients;

public interface IAzureDevOpsClient : IProjectClient, IWorkItemClient
{
}
