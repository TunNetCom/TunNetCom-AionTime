using Microsoft.AspNetCore.Mvc;
using OneOf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProjectService
{
    public class ProjectService(HttpClient httpClient, ILogger<ProjectService> logger) : IProjectService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<ProjectService> _logger = logger;

        public async Task<OneOf<AllProjectResponce?, CustomProblemDetailsResponce?>> AllProjectUnderOrganisation(AllProjectUnderOrganizationRequest request)
        {
            HttpClientHelper.SetAuthHeader(_httpClient, request.Path);

            HttpResponseMessage result = await _httpClient.GetAsync("_apis/profile/profiles/me?api-version=7.0");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                AllProjectResponce? res = await result.Content.ReadFromJsonAsync<AllProjectResponce>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                res.Path = request.Path;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                res.Email = request.Email;
                return res;
            }

            _logger.LogError(await result.Content.ReadAsStringAsync());
            return new CustomProblemDetailsResponce()
            {
                Path = request.Path,
                Email = request.Email,
                Status = (int)result.StatusCode,
                Detail = "pleas verify your Azure Devops Key or your organization name",
            };
        }
    }
}