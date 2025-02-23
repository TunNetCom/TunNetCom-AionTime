namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IProjectService
{
    Task<OneOf<AllProjectResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(AllProjectUnderOrganizationRequest request);
}