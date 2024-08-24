namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

public class Column
{
    public string ReferenceName { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

#pragma warning disable CA1056 // URI-like properties should not be strings
    public string Url { get; set; } = string.Empty;
#pragma warning restore CA1056 // URI-like properties should not be strings
}