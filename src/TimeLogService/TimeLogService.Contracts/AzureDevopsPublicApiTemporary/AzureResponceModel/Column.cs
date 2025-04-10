namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;

public class Column
{
    public string ReferenceName { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public required Uri Url { get; set; }
}