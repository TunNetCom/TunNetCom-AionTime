namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService
{
    public interface IUserProfileApiClient
    {
        Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(BaseRequest request);

        Task<OneOf<UserAccount, CustomProblemDetailsResponce>> GeUserOrganizations(GetUserOrganizationRequest request);
    }
}