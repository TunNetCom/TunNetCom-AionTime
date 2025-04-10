using Microsoft.Extensions.Logging;
using OneOf;
using System.Net;
using System.Net.Http.Json;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.Constant;
using TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService.ServiceHelper;

namespace TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService;

public class ProjectService(HttpClient httpClient, ILogger<ProjectService> logger) : IProjectService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<ProjectService> _logger = logger;

    public async Task<OneOf<OrganizationProjectsResponce, CustomProblemDetailsResponce>> AllProjectUnderOrganization(string organizationName, string path)
    {
        HttpClientHelper.SetAuthHeader(_httpClient, path);

        HttpResponseMessage projectsResult = await _httpClient.GetAsync($"{organizationName}{AzureUrlsEndPoint.Projects}");

        if (projectsResult.StatusCode == HttpStatusCode.OK)
        {
            OrganizationProjectsResponce? projects = await projectsResult.Content.ReadFromJsonAsync<OrganizationProjectsResponce>();

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