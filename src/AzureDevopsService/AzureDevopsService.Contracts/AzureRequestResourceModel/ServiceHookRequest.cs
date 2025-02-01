namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public class ServiceHookReques : InternalBaseRequest
{
    [JsonProperty("publisherId")]
    public string PublisherId { get; set; }

    [JsonProperty("eventType")]
    public string EventType { get; set; }

    [JsonProperty("consumerId")]
    public string ConsumerId { get; set; }

    [JsonProperty("consumerActionId")]
    public string ConsumerActionId { get; set; }

    [JsonProperty("consumerInputs")]
    public ConsumerInputs ConsumerInputs { get; set; }

    [JsonProperty("publisherInputs")]
    public PublisherInputs PublisherInputs { get; set; }
}