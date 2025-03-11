namespace AzureDevopsService.Contracts.Internal.Interface;

public interface IUserProfileApiClient
{
    Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(string path);

    Task<OneOf<UserAccountOrganization, CustomProblemDetailsResponce>> GeUserOrganizations(string memberId, string path);
}