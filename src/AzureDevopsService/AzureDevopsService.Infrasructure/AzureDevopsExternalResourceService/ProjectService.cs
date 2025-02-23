namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService;

public class ProjectService(HttpClient httpClient, ILogger<ProjectService> logger) : IProjectService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<ProjectService> _logger = logger;

    public async Task<OneOf<AllProjectResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(AllProjectUnderOrganizationRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage projectsResult = await _httpClient.GetAsync($"{request.OrganizationName}{AzureUrlsEndPoint.Projects}");

        if (projectsResult.StatusCode == HttpStatusCode.OK)
        {
            AllProjectResponce? projects = await projectsResult.Content.ReadFromJsonAsync<AllProjectResponce>();
            projects!.Path = request.Path;
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