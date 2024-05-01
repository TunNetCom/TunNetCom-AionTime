using TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems.Contracts;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems;

public interface IWorkItemClient
{
    Task<OneOf<WiqlResponses?, WiqlBadRequest?>> GetWiqlResponses(WiqlRequest wiqlRequest);
}
