namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;

public class WorkItem
{
    public int Id { get; set; }

    public required Uri Url { get; set; }
}