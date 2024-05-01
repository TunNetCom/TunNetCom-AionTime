using TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects.Contracts;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects;

public interface IProjectClient
{
    Task<GetAllProjectsResponse?> GetAll(BaseRequest baseRequest);
}
