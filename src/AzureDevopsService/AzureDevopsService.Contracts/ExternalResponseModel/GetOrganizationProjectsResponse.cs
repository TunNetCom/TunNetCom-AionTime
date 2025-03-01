namespace AzureDevopsService.Contracts.ExternalResponseModel;

public class GetOrganizationProjectsResponse : BaseRequest
{
    public required string OrganizationId { get; set; }

    public required string OrganizationName { get; set; }

    public required OrganizationProjects OrganizationProjects { get; set; }
}