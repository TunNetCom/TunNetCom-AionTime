namespace AzureDevopsService.Contracts.AzureResponceModel;

public class WorkItem
{
    public int Id { get; set; }

#pragma warning disable CA1056 // URI-like properties should not be strings
    public string Url { get; set; } = string.Empty;
#pragma warning restore CA1056 // URI-like properties should not be strings
}