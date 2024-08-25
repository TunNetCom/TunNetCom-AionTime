using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.OrganizationProjectService;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.OrganizationProjectService
{
    public class ProjectService(HttpClient httpClient, ILogger<ProjectService> logger) : IProjectService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<ProjectService> _logger = logger;

        public async Task<OneOf<AllProjectResponce?, CustomProblemDetailsResponce?>> AllProjectUnderOrganization(AllProjectUnderOrganizationRequest request)
        {
            HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

            HttpResponseMessage projectsResult = await _httpClient.GetAsync("_apis/profile/profiles/me?api-version=7.0");

            if (projectsResult.StatusCode == HttpStatusCode.OK)
            {
                AllProjectResponce? projects = await projectsResult.Content.ReadFromJsonAsync<AllProjectResponce>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                projects.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                projects.Email = request.Email;
                return projects;
            }

            _logger.LogError(await projectsResult.Content.ReadAsStringAsync());
            return new CustomProblemDetailsResponce()
            {
                Path = request.Path,
                Email = request.Email,
                Status = (int)projectsResult.StatusCode,
                Detail = AzureResponseMessage.VerifyAzureDevOpsKeyOrOrgName,
            };
        }
    }
}