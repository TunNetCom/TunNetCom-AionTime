namespace AzureDevopsService.Contracts.AzureResponceModel.SuccessResponce;

public class WebhookResponce
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("publisherId")]
    public string PublisherId { get; set; }

    [JsonProperty("eventType")]
    public string EventType { get; set; }

    [JsonProperty("subscriber")]
    public object Subscriber { get; set; }

    [JsonProperty("resourceVersion")]
    public object ResourceVersion { get; set; }

    [JsonProperty("eventDescription")]
    public string EventDescription { get; set; }

    [JsonProperty("consumerId")]
    public string ConsumerId { get; set; }

    [JsonProperty("consumerActionId")]
    public string ConsumerActionId { get; set; }

    [JsonProperty("actionDescription")]
    public string ActionDescription { get; set; }

    [JsonProperty("createdBy")]
    public UserInfo CreatedBy { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("modifiedBy")]
    public UserInfo ModifiedBy { get; set; }

    [JsonProperty("modifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [JsonProperty("lastProbationRetryDate")]
    public DateTime LastProbationRetryDate { get; set; }

    [JsonProperty("publisherInputs")]
    public PublisherInputsWebhookResponce PublisherInputs { get; set; }

    [JsonProperty("consumerInputs")]
    public ConsumerInputs ConsumerInputs { get; set; }

    [JsonProperty("_links")]
    public Links Links { get; set; }
}