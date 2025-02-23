namespace AzureDevopsService.Contracts.SharedModel;

public class ConsumerInputs
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("httpHeaders")]
    public string HttpHeaders { get; set; }

    [JsonProperty("resourceDetailsToSend")]
    public string ResourceDetailsToSend { get; set; }
}