namespace TimeLogService.Application.Feature.MessageBroker.Consumer.WebhookConsumer;

public class WorkItemEventConsumer(ILogger<WorkItemEventConsumer> logger) : IConsumer<AzureWebhookModelEvent<WorkItemResource>>
{
    private readonly ILogger<WorkItemEventConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<WorkItemResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}