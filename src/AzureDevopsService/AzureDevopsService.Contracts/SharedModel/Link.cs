namespace AzureDevopsService.Contracts.SharedModel;

public class Link
{
    [JsonProperty("href")]
    public string Href { get; set; }
}