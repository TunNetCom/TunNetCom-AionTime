namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProjectService
{
    public interface IProjectService
    {
        Task<OneOf<AllProjectResponce?, CustomProblemDetailsResponce?>> AllProjectUnderOrganisation(AllProjectUnderOrganizationRequest request);
    }
}