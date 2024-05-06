namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems.Contracts;

public class WiqlRequest : BaseRequest
{
    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;
}