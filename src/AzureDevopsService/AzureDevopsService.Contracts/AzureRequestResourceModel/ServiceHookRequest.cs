namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public class ServiceHookReques : InternalBaseRequest
{
    [JsonProperty("publisherId")]
    public required string PublisherId { get; set; }

    [JsonProperty("eventType")]
    public required string EventType { get; set; }

    [JsonProperty("consumerId")]
    public required string ConsumerId { get; set; }

    [JsonProperty("consumerActionId")]
    public required string ConsumerActionId { get; set; }

    [JsonProperty("consumerInputs")]
    public required ConsumerInputs ConsumerInputs { get; set; }

    [JsonProperty("publisherInputs")]
    public required PublisherInputs PublisherInputs { get; set; }
}