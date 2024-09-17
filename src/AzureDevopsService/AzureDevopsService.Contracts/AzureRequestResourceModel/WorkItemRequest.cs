namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public class WorkItemRequest : BaseRequest
{
    public required string OrganisationName { get; set; }

    public required string ProjectName { get; set; }
}