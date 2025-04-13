namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureRequestResourceModel;

public class AzureDevopsWorkItemRequest : BaseRequest
{
    public required string OrganisationName { get; set; }

    public required string ProjectName { get; set; }
}