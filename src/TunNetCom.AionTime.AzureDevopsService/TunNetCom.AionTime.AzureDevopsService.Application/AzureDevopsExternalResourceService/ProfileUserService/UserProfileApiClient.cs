using TunNetCom.AionTime.AzureDevopsService.Contracts.Constant;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService;

public class UserProfileApiClient(HttpClient httpClient, ILogger<UserProfileApiClient> logger) : IUserProfileApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<UserProfileApiClient> _logger = logger;

    public async Task<OneOf<UserProfile?, CustomProblemDetailsResponce?>> GetAdminInfo(BaseRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage userProfileResult = await _httpClient.GetAsync("_apis/profile/profiles/me?api-version=7.0");

        if (userProfileResult.StatusCode == HttpStatusCode.OK)
        {
            UserProfile? user = await userProfileResult.Content.ReadFromJsonAsync<UserProfile>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            user.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            user.Email = request.Email;
            return user;
        }

        _logger.LogError(await userProfileResult.Content.ReadAsStringAsync());
        return new CustomProblemDetailsResponce()
        {
            Email = request.Email,
            Path = request.Path,
            Status = (int)userProfileResult.StatusCode,
            Detail = AzureResponseMessage.VerifyAzureDevOpsKey,
        };
    }

    public async Task<OneOf<UserAccount?, CustomProblemDetailsResponce?>> GeUserOrganizations(GetUserOrganizationRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage userOrganizationResult = await _httpClient.GetAsync($"_apis/accounts?memberId={request.MemberId}&api-version=7.0");

        if (userOrganizationResult.StatusCode == HttpStatusCode.OK)
        {
            UserAccount? responce = await userOrganizationResult.Content.ReadFromJsonAsync<UserAccount>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            responce.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            responce.Email = request.Email;

            return responce;
        }

        _logger.LogError(await userOrganizationResult.Content.ReadAsStringAsync());

        return new CustomProblemDetailsResponce()
        {
            Email = request.Email,
            Path = request.Path,
            Status = (int)userOrganizationResult.StatusCode,
            Detail = AzureResponseMessage.VerifyAzureDevOpsKey,
        };
    }
}