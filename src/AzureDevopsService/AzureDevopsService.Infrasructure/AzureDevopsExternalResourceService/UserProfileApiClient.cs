namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService;

public class UserProfileApiClient(HttpClient httpClient, ILogger<UserProfileApiClient> logger) : IUserProfileApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<UserProfileApiClient> _logger = logger;

    public async Task<OneOf<UserProfile, CustomProblemDetailsResponce>> GetAdminInfo(AzureAdminInfoRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage userProfileResult = await _httpClient.GetAsync(AzureUrlsEndPoint.Profiles);

        if (userProfileResult.StatusCode == HttpStatusCode.OK)
        {
            UserProfile? user = await userProfileResult.Content.ReadFromJsonAsync<UserProfile>();

            user!.Path = request.Path;
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

    public async Task<OneOf<UserAccount, CustomProblemDetailsResponce>> GeUserOrganizations(GetUserOrganizationRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage userOrganizationResult = await _httpClient.GetAsync($"_apis/accounts?memberId={request.MemberId}&api-version=7.0");

        if (userOrganizationResult.StatusCode == HttpStatusCode.OK)
        {
            UserAccount? responce = await userOrganizationResult.Content.ReadFromJsonAsync<UserAccount>();
            responce!.Path = request.Path;
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