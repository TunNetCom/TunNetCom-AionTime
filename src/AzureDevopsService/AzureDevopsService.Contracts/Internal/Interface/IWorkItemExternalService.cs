namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IWorkItemExternalService
{
    Task<OneOf<WiqlResponses, WiqlBadRequestResponce>> GetWorkItemByUser(WorkItemRequest resource);
}