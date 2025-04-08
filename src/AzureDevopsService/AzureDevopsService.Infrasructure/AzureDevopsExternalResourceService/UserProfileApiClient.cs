using AzureDevopsService.Contracts.Internal.Interfaces;

namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService;

public class UserProfileApiClient(HttpClient httpClient, ILogger<UserProfileApiClient> logger) : IUserProfileApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<UserProfileApiClient> _logger = logger;

    public async Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(string path)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, path);

        HttpResponseMessage userProfileResult = await _httpClient.GetAsync(AzureUrlsEndPoint.Profiles);

        if (userProfileResult.StatusCode == HttpStatusCode.OK)
        {
            UserProfile? user = await userProfileResult.Content.ReadFromJsonAsync<UserProfile>();

            if (user != null)
            {
                return user;
            }
        }

        _logger.LogError(await userProfileResult.Content.ReadAsStringAsync());
        return new CustomProblemDetailsResponce()
        {
            Status = (int)userProfileResult.StatusCode,
            Detail = AzureResponseMessage.VerifyAzureDevOpsKey,
        };
    }

    public async Task<OneOf<UserAccountOrganization, CustomProblemDetailsResponce>> GeUserOrganizations(string memberId, string path)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, path);

        HttpResponseMessage userOrganizationResult = await _httpClient.GetAsync($"_apis/accounts?memberId={memberId}&api-version=7.0");

        if (userOrganizationResult.StatusCode == HttpStatusCode.OK)
        {
            UserAccountOrganization? responce = await userOrganizationResult.Content.ReadFromJsonAsync<UserAccountOrganization>();

            if (responce != null)
            {
                return responce;
            }
        }

        _logger.LogError(await userOrganizationResult.Content.ReadAsStringAsync());

        return new CustomProblemDetailsResponce()
        {
            Status = (int)userOrganizationResult.StatusCode,
            Detail = AzureResponseMessage.VerifyAzureDevOpsKey,
        };
    }
}