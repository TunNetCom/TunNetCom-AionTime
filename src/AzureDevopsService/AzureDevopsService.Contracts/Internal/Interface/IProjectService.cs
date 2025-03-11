namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IProjectService
{
    Task<OneOf<OrganizationProjects, CustomProblemDetailsResponce>> AllProjectUnderOrganization(string organizationName, string path);
}