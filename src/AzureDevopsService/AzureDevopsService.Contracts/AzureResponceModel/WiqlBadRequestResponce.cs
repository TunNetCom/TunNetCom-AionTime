namespace AzureDevopsService.Contracts.AzureResponceModel;

public class WiqlBadRequestResponce : BaseRequest
{
    [JsonProperty("$id")]
    public string? Id { get; set; } = string.Empty;

    [JsonProperty("innerException")]
    public string InnerException { get; set; } = string.Empty;

    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;

    [JsonProperty("typeName")]
    public string TypeName { get; set; } = string.Empty;

    [JsonProperty("typeKey")]
    public string TypeKey { get; set; } = string.Empty;

    [JsonProperty("errorCode")]
    public int ErrorCode { get; set; }

    [JsonProperty("eventId")]
    public int EventId { get; set; }
}