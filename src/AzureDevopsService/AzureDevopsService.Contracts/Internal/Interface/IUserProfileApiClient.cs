namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IUserProfileApiClient
{
    Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(AzureAdminInfoRequest request);

    Task<OneOf<UserAccount, CustomProblemDetailsResponce>> GeUserOrganizations(GetUserOrganizationRequest request);
}