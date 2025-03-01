using AzureDevopsService.Contracts.ExternalRequestModel;

namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService;

public class ProjectService(HttpClient httpClient, ILogger<ProjectService> logger) : IProjectService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<ProjectService> _logger = logger;

    public async Task<OneOf<OrganizationProjects, CustomProblemDetailsResponce>> AllProjectUnderOrganization(GetOrganizationProjectsRequest request)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

        HttpResponseMessage projectsResult = await _httpClient.GetAsync($"{request.OrganizationName}{AzureUrlsEndPoint.Projects}");

        if (projectsResult.StatusCode == HttpStatusCode.OK)
        {
            OrganizationProjects? projects = await projectsResult.Content.ReadFromJsonAsync<OrganizationProjects>();

            return projects;
        }

        _logger.LogError(await projectsResult.Content.ReadAsStringAsync());
        return new CustomProblemDetailsResponce()
        {
            Status = (int)projectsResult.StatusCode,
            Detail = AzureResponseMessage.VerifyAzureDevOpsKeyOrOrgName,
        };
    }
}