using Microsoft.EntityFrameworkCore;
using System;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary;
using TimeLogService.Domain.Interfaces.Repositories;
using TimeLogService.Domain.Models.dbo;
using TimeLogService.Domain.Models.Dbo;

namespace TimeLogService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLogServiceController(
    IMediator mediator,
    IProjectService projectsApiClient,
    IWorkItemExternalService workItemExternalService,
    IRepository<Project> projectRepository,
    IRepository<WorkItem> workitemRepository,
    IRepository<WorkItemComment> workitemCommentRepository,
    IRepository<Organization> organizationRepository,
    TimeLogServiceDataBaseContext context
    ) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("tmp_get_azure_projects")]
    public async Task<IActionResult> GetAzureProjects(string organizationName, string pat)
    {
        var organization = await organizationRepository.GetSingleAsync(x => x.Name == organizationName);
        
        var res = await projectsApiClient.AllProjectUnderOrganization(organizationName, pat);
        if (res.IsT1)
        {
            return BadRequest(res.AsT1);
        }

        if (organization is null)
        {
            await organizationRepository.AddAsync(new Organization
            {
                Name = organizationName,
                TenantId = "xxxxxx",
                Pat = pat,
                IsAionTimeApproved = true,
            });

            organization = await organizationRepository.GetSingleAsync(x => x.Name == organizationName);
        }
        var projects = res.AsT0.Value.Select(x => new Project
        {
            Name = x.Name,
            OrganizationId = organization.Id,
            AzureProjectId = x.Id,
            State = x.State,
            Url = x.Url,
            Visibility = x.Visibility,
            LastUpdateTime = x.LastUpdateTime,
            TenantId = "xxxxxx"
        });

        await projectRepository.AddRangeAsync(projects);

        return Ok();
    }

    [HttpPost]
    [Route("tmp_get_azure_projects_workitems")]
    public async Task<IActionResult> GetProjectsWorkitems(string organizationName,string projectName,string pat)
    {
        var project = await projectRepository.GetSingleAsync(x => x.Name == projectName);

        var res = await workItemExternalService.GetWorkITemsIds(organizationName, projectName, pat);
        if (res.IsT1)
        {
            return BadRequest(res.AsT1);
        }

        foreach (var workItem in res.AsT0.WorkItems)
        {
            var workItemDetails = await workItemExternalService.GetWorkItemDetails(organizationName, projectName, workItem.Id.ToString(), pat);
            if (workItemDetails.IsT1)
            {
                return BadRequest(workItemDetails.AsT1);
            }
            var workItemDbo = new WorkItem
            {
                Title = workItemDetails.AsT0.Fields.SystemTitle,
                State = workItemDetails.AsT0.Fields.SystemState,
                AzureId = workItem.Id,
                Type = workItemDetails.AsT0.Fields.SystemWorkItemType,
                CreatedDate = workItemDetails.AsT0.Fields.SystemCreatedDate,
                WorkItemUrl = workItemDetails.AsT0.Url,
                ProjectId = project.Id,
                TenantId = "xxxxxx"
            };
            await workitemRepository.AddAsync(workItemDbo);

            var Comments = await workItemExternalService.GetWorkITemComments(new Uri(workItemDetails.AsT0.Links.WorkItemComments.Href), pat);
            if(Comments.IsT1)
            {
                return BadRequest(Comments.AsT1);
            }
            if (Comments.AsT0.Comments.Count >0)
            {
                var workitemdb =await workitemRepository.GetSingleAsync(x => x.AzureId== Comments.AsT0.Comments[0].WorkItemId);

                var workItemCommentDbo = Comments.AsT0.Comments.Select(x => new WorkItemComment
                {
                    CommentText = x.Text,
                    AzureWorkItemId = x.WorkItemId,
                    WorkItemId = workitemdb.Id,
                    CreatedDate = x.CreatedDate,
                    AzureCommentId = x.Id,
                    CreatedByUserEmail = x.CreatedBy.UniqueName,
                    CommentFormat = x.Format,
                    CommentUrl = new Uri(x.Url),
                    Version = x.Version,
                    CreatedByUserDisplayName = x.CreatedBy.DisplayName,
                    CreatedByUserId = x.CreatedBy.Id,
                    TenantId = "xxxxxx"
                });

                await workitemCommentRepository.AddRangeAsync(workItemCommentDbo);

            }



        }

        return Ok();
    }

    [HttpPost]
    [Route("tmp_get_azure_projects_fromDataBase")]
    public async Task<IActionResult> GetAzureProjectsFromDatabse()
    {
        return Ok(await projectRepository.GetAsync());
    }

    [HttpPost]
    [Route("tmp_get_azure_workitems_fromDataBase")]
    public async Task<IActionResult> GetProjectsWorkitemsFromDatabse()
    {
        var result = await context.WorkItems
        .Include(x => x.WorkItemComments)
        .ToListAsync();

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var json = JsonConvert.SerializeObject(result, settings);
        return Content(json, "application/json");
    }

    [HttpPost]
    [Route("tmp_get_azure_workitems_by_azureId_fromDataBase")]
    public async Task<IActionResult> GetProjectsWorkitemsFromDatabse(int azureId)
    {
        var result = await context.WorkItems
        .Include(x => x.WorkItemComments)
        .Where(x => x.AzureId== azureId)
        .ToListAsync();

        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        var json = JsonConvert.SerializeObject(result, settings);
        return Content(json, "application/json");
    }
}