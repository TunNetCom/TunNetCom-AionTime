namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.WorkItem
{
    public interface IWorkItemExternalService
    {
        Task<OneOf<WiqlResponses?, WiqlBadRequestResponce?>> GetWorkItemByUser(WorkItemRequest resource);
    }
}