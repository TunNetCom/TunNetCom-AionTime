using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.WorkItem
{
    public interface IWorkItemExternalService
    {
        Task<OneOf<WiqlResponses?, WiqlBadRequestResponce?>> GetWorkItemByUser(WorkItemRequest resource);
    }
}