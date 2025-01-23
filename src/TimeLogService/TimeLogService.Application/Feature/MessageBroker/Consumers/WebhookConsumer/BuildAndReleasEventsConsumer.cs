namespace TimeLogService.Application.Feature.MessageBroker.Consumer.WebhookConsumer;

public class BuildAndReleasEventsConsumer(ILogger<BuildAndReleasEventsConsumer> logger) : IConsumer<AzureWebhookModelEvent<BuildAndReleaseResource>>
{
    private readonly ILogger<BuildAndReleasEventsConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<BuildAndReleaseResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}