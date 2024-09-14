namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WebhookConsumer;

public class CodeEventsConsumer(ILogger<CodeEventsConsumer> logger) : IConsumer<AzureWebhookModelEvent<CodeResource>>
{
    private readonly ILogger<CodeEventsConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<CodeResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}