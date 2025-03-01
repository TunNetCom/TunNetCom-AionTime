namespace AzureDevopsService.Contracts.AzureResponceModel;

public class WorkItem
{
    public int Id { get; set; }

    public required Uri Url { get; set; }
}