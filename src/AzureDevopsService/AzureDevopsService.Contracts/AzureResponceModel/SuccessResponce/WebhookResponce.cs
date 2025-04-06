namespace AzureDevopsService.Contracts.AzureResponceModel.SuccessResponce;

public class WebhookResponce
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("url")]
    public required string Url { get; set; }

    [JsonProperty("status")]
    public required string Status { get; set; }

    [JsonProperty("publisherId")]
    public required string PublisherId { get; set; }

    [JsonProperty("eventType")]
    public required string EventType { get; set; }

    [JsonProperty("subscriber")]
    public required object Subscriber { get; set; }

    [JsonProperty("resourceVersion")]
    public required object ResourceVersion { get; set; }

    [JsonProperty("eventDescription")]
    public required string EventDescription { get; set; }

    [JsonProperty("consumerId")]
    public required string ConsumerId { get; set; }

    [JsonProperty("consumerActionId")]
    public required string ConsumerActionId { get; set; }

    [JsonProperty("actionDescription")]
    public required string ActionDescription { get; set; }

    [JsonProperty("createdBy")]
    public required UserInfo CreatedBy { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("modifiedBy")]
    public required UserInfo ModifiedBy { get; set; }

    [JsonProperty("modifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [JsonProperty("lastProbationRetryDate")]
    public DateTime LastProbationRetryDate { get; set; }

    [JsonProperty("publisherInputs")]
    public required PublisherInputsWebhookResponce PublisherInputs { get; set; }

    [JsonProperty("consumerInputs")]
    public required ConsumerInputs ConsumerInputs { get; set; }

    [JsonProperty("_links")]
    public required Links Links { get; set; }
}