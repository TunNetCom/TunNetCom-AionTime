namespace AzureDevopsService.Contracts.AzureResponceModel.BadRequest;

public class WebhookBadRequestResponce
{
    [JsonProperty("$id")]
    public string Id { get; set; }

    [JsonProperty("innerException")]
    public object InnerException { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("typeName")]
    public string TypeName { get; set; }

    [JsonProperty("typeKey")]
    public string TypeKey { get; set; }

    [JsonProperty("errorCode")]
    public int ErrorCode { get; set; }

    [JsonProperty("eventId")]
    public int EventId { get; set; }
}