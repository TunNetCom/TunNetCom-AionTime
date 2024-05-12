namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers;

public interface IPatResolver
{
    Task<string?> GetPatAsync(string organizationName);
}