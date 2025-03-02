namespace AzureDevopsService.Contracts.ExternalRequestModel;

public class GetOrganizationProjectsRequest : BaseRequest
{
    public required string OrganizationId { get; set; }

    public required string OrganizationName { get; set; }
}