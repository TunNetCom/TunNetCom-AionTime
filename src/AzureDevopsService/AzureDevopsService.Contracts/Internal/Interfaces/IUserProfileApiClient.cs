namespace AzureDevopsService.Contracts.Internal.Interfaces;

public interface IUserProfileApiClient
{
    Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(string path);

    Task<OneOf<UserAccountOrganization, CustomProblemDetailsResponce>> GeUserOrganizations(
        string memberId,
        string path);
}