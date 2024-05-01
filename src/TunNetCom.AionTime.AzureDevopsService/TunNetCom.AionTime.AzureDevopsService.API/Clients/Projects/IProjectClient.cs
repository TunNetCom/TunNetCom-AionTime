namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Projects;

public interface IProjectClient
{
    Task<GetAllProjectsResponse?> GetAll(BaseRequest baseRequest);
}
