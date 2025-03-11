namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public abstract class BaseRequest
{
    public string Email { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public required string TenantId { get; set; }
}