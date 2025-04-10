using OneOf;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureRequestResourceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.SharedModel;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary;

public interface IWorkItemExternalService
{
    Task<OneOf<WiqlResponses, WiqlBadRequestResponce>> GetWorkItemByUser(AzureDevopsWorkItemRequest resource);
    Task<OneOf<WorkItemsIdsResponse, CustomProblemDetailsResponce>> GetWorkITemsIds(string organizationName,string projectName, string path);

    Task<OneOf<WorkItemDetails, CustomProblemDetailsResponce>> GetWorkItemDetails(string organizationName, string projectName, string workItemId, string path);
    Task<OneOf<WorkItemCommentsResponse, CustomProblemDetailsResponce>> GetWorkITemComments(Uri uri, string pat);
}