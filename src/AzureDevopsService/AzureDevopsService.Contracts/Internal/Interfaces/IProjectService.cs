namespace AzureDevopsService.Contracts.Internal.Interfaces;

public interface IProjectService
{
    Task<OneOf<OrganizationProjectsResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(
        string organizationName,
        string path);
}