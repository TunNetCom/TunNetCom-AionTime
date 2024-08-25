namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.OrganizationProjectService;

public interface IProjectService
{
    Task<OneOf<AllProjectResponce?, CustomProblemDetailsResponce?>> AllProjectUnderOrganization(AllProjectUnderOrganizationRequest request);
}