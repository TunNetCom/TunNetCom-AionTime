namespace AzureDevopsService.Contracts.SharedModel;

public class PublisherInputs
{
    [JsonProperty("projectId")]
    public string ProjectId { get; set; }
}