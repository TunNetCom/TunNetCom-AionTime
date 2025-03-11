namespace AzureDevopsService.Infrasructure.AzureDevopsExternalResourceService.ServiceHelper.WorkItem;

public static class WorkItemHelper
{
    public static WiqlRequest FillGetWorkItemByUser(WorkItemRequest resource)
    {
        return new()
        {
            TenantId = resource.TenantId,
            ApiVersion = "v5",
            Organization = resource.OrganisationName,
            Project = resource.ProjectName,
            Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
            Query = $@"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath] 
                    FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> '' 
                    AND EVER [System.AssignedTo] = '{resource.Email}'",
        };
    }

    public static WiqlRequest FillGetWorkItemsIdsUnderProject(WorkItemRequest resource)
    {
        return new()
        {
            TenantId = resource.TenantId,
            ApiVersion = "v5",
            Organization = resource.OrganisationName,
            Project = resource.ProjectName,
            Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
            Query = $@"SELECT [System.Id] FROM WorkItems WHERE [System.TeamProject] = 'YourProjectName'",
        };
    }
}