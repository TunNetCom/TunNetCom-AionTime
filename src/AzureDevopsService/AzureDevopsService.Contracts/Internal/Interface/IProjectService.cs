namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IProjectService
{
    Task<OneOf<OrganizationProjectsResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(string organizationName, string path);
}