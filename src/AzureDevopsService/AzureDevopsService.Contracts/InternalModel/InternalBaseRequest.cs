namespace AzureDevopsService.Contracts.InternalModel;

public class InternalBaseRequest
{
    [JsonIgnore]
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string Path { get; set; } = string.Empty;

    [JsonIgnore]
    public string OrganizationName { get; set; } = string.Empty;
}