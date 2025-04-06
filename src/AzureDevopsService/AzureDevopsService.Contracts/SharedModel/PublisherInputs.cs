namespace AzureDevopsService.Contracts.SharedModel;

public class PublisherInputs
{
    [JsonProperty("projectId")]
    public required string ProjectId { get; set; }
}