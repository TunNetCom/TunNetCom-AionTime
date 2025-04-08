namespace AzureDevopsService.Contracts.Internal.Interfaces;

public interface IWorkItemExternalService
{
    Task<OneOf<WiqlResponses, WiqlBadRequestResponce>> GetWorkItemByUser(WorkItemRequest resource);
}