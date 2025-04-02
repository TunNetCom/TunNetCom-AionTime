namespace TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.WebhookIntegrationEvent;

public class PipelineEvents(ILogger<PipelineEvents> logger) : IConsumer<AzureWebhookModelEvent<PipeLinesResource>>
{
    private readonly ILogger<PipelineEvents> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<PipeLinesResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}