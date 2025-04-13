using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OneOf;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureRequestResourceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.Constant;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.SharedModel;
using TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService.ServiceHelper;
using TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService.ServiceHelper.WorkItem;

namespace TimeLogService.Infrastructure.AzureDevopsPublicApiTempraryService;

public class WorkItemExternalService(HttpClient httpClient, ILogger<WorkItemExternalService> logger) : IWorkItemExternalService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<WorkItemExternalService> _logger = logger;

    public async Task<OneOf<WiqlResponses, WiqlBadRequestResponce>> GetWorkItemByUser(AzureDevopsWorkItemRequest resource)
    {
        WiqlRequest wiqlRequest = WorkItemHelper.FillGetWorkItemByUser(resource);

        HttpClientHelper.SetAuthHeader(_httpClient, resource.Path);

        using HttpResponseMessage workItemResponse = await _httpClient.PostAsJsonAsync(
            @$"/{wiqlRequest.Organization}/{wiqlRequest.Project}/{wiqlRequest.Team}/_apis/wit/wiql?api-version={wiqlRequest.ApiVersion}",
            wiqlRequest);

        if (workItemResponse.StatusCode == HttpStatusCode.OK)
        {
            WiqlResponses? wiqlResponses = await workItemResponse.Content.ReadFromJsonAsync<WiqlResponses>();
            wiqlResponses!.Email = wiqlRequest.Email;
            wiqlResponses.Path = wiqlRequest.Path;
            return wiqlResponses;
        }

        _logger.LogError(await workItemResponse.Content.ReadAsStringAsync());

        if (workItemResponse.StatusCode == HttpStatusCode.BadRequest)
        {
            WiqlBadRequestResponce? wiqlBadResponses = await workItemResponse.Content.ReadFromJsonAsync<WiqlBadRequestResponce>();
            wiqlBadResponses!.Path = wiqlRequest.Path;
            wiqlBadResponses.Email = wiqlRequest.Email;

            return wiqlBadResponses;
        }

        return new WiqlBadRequestResponce()
        {
            Email = resource.Email,
            TenantId = resource.TenantId,
            ErrorCode = (int)workItemResponse.StatusCode,
            Message = AzureResponseMessage.WorkItemError,
            Path = resource.Path,
        };
    }

    public async Task<OneOf<WorkItemDetails, CustomProblemDetailsResponce>> GetWorkItemDetails(string organizationName, string projectName, string workItemId, string path)
    {
        string wiqlRequest = WorkItemHelper.FillGetWorkItemsIdsUnderProject(projectName);

        HttpClientHelper.SetAuthHeader(_httpClient, path);

        using HttpResponseMessage workItemResponse = await _httpClient.GetAsync(@$"/{organizationName}/{projectName}/_apis/wit/workitems/{workItemId}?api-version=7.0&$expand=all");

        if (workItemResponse.StatusCode == HttpStatusCode.OK)
        {
            WorkItemDetails? workItemDetails = JsonConvert.DeserializeObject<WorkItemDetails>(await workItemResponse.Content.ReadAsStringAsync());

            return workItemDetails;
        }
        return new CustomProblemDetailsResponce()
        {
            Status = (int)workItemResponse.StatusCode,
            Detail = await workItemResponse.Content.ReadAsStringAsync(),
        };
    }

    public async Task<OneOf<WorkItemsIdsResponse, CustomProblemDetailsResponce>> GetWorkITemsIds(string organizationName, string projectName, string path)
    {
        string wiqlRequest = WorkItemHelper.FillGetWorkItemsIdsUnderProject(projectName);

        HttpClientHelper.SetAuthHeader(_httpClient, path);
        var query = new
        {
            query = $"{wiqlRequest}"
        };
        using HttpResponseMessage workItemResponse = await _httpClient.PostAsJsonAsync(
            @$"/{organizationName}/{projectName}/_apis/wit/wiql?api-version=7.0",
            query);

        if (workItemResponse.StatusCode == HttpStatusCode.OK)
        {
            WorkItemsIdsResponse? workItemsIdsResponse = await workItemResponse.Content.ReadFromJsonAsync<WorkItemsIdsResponse>();

            return workItemsIdsResponse;
        }
        return new CustomProblemDetailsResponce()
        {
            Status = (int)workItemResponse.StatusCode,
            Detail = await workItemResponse.Content.ReadAsStringAsync(),
        };
    }

    public async Task<OneOf<WorkItemCommentsResponse, CustomProblemDetailsResponce>> GetWorkITemComments(Uri uri,string pat)
    {

        HttpClientHelper.SetAuthHeader(_httpClient, pat);

        using HttpResponseMessage workItemResponse = await _httpClient.GetAsync(uri);

        if (workItemResponse.StatusCode == HttpStatusCode.OK)
        {
            WorkItemCommentsResponse? workItemsIdsResponse = await workItemResponse.Content.ReadFromJsonAsync<WorkItemCommentsResponse>();

            return workItemsIdsResponse;
        }
        return new CustomProblemDetailsResponce()
        {
            Status = (int)workItemResponse.StatusCode,
            Detail = await workItemResponse.Content.ReadAsStringAsync(),
        };
    }
}