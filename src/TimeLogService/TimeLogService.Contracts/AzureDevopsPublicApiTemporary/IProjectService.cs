using OneOf;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary;

public interface IProjectService
{
    Task<OneOf<OrganizationProjectsResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(
        string organizationName,
        string path);
}