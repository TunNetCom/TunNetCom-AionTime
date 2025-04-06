namespace AzureDevopsService.Contracts.AzureResponceModel.BadRequest;

public class WebhookBadRequestResponce
{
    [JsonProperty("$id")]
    public required string Id { get; set; }

    [JsonProperty("innerException")]
    public required object InnerException { get; set; }

    [JsonProperty("message")]
    public required string Message { get; set; }

    [JsonProperty("typeName")]
    public required string TypeName { get; set; }

    [JsonProperty("typeKey")]
    public required string TypeKey { get; set; }

    [JsonProperty("errorCode")]
    public int ErrorCode { get; set; }

    [JsonProperty("eventId")]
    public int EventId { get; set; }
}