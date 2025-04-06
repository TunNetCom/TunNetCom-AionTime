namespace AzureDevopsService.Contracts.SharedModel;

public class Link
{
    [JsonProperty("href")]
    public required string Href { get; set; }
}