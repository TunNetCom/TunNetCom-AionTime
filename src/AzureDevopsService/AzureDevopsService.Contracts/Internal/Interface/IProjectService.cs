using AzureDevopsService.Contracts.ExternalRequestModel;

namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IProjectService
{
    Task<OneOf<OrganizationProjects, CustomProblemDetailsResponce>> AllProjectUnderOrganization(GetOrganizationProjectsRequest request);
}