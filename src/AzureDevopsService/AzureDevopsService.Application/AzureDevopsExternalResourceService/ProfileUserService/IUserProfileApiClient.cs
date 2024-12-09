using AzureDevopsService.Contracts.AzureRequestModel;

namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService
{
    public interface IUserProfileApiClient
    {
        Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(AzureAdminInfoRequest request);

        Task<OneOf<UserAccount, CustomProblemDetailsResponce>> GeUserOrganizations(GetUserOrganizationRequest request);
    }
}