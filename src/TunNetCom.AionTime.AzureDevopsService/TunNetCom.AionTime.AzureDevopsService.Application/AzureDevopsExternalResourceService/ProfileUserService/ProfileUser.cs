using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService;

public class ProfileUser(HttpClient httpClient, ILogger<ProfileUser> logger) : IProfileUser
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<ProfileUser> _logger = logger;

    public async Task<OneOf<UserProfile?, CustomProblemDetailsResponce?>> GetAdminInfo(BaseRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage result = await _httpClient.GetAsync("_apis/profile/profiles/me?api-version=7.0");

        if (result.StatusCode == HttpStatusCode.OK)
        {
            UserProfile? user = await result.Content.ReadFromJsonAsync<UserProfile>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            user.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            user.Email = request.Email;
            return user;
        }

        _logger.LogError(await result.Content.ReadAsStringAsync());
        return new CustomProblemDetailsResponce()
        {
            Email = request.Email,
            Path = request.Path,
            Status = (int)result.StatusCode,
            Detail = "pleas verify your Azure Devops Key",
        };
    }

    public async Task<OneOf<UserAccount?, CustomProblemDetailsResponce?>> GeUserOrganizations(GetUserOrganizationRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage result = await _httpClient.GetAsync($"_apis/accounts?memberId={request.MemberId}&api-version=7.0");

        if (result.StatusCode == HttpStatusCode.OK)
        {
            UserAccount? res = await result.Content.ReadFromJsonAsync<UserAccount>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            res.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            res.Email = request.Email;

            return res;
        }

        _logger.LogError(await result.Content.ReadAsStringAsync());

        return new CustomProblemDetailsResponce()
        {
            Email = request.Email,
            Path = request.Path,
            Status = (int)result.StatusCode,
            Detail = "pleas verify your Azure Devops Key",
        };
    }
}