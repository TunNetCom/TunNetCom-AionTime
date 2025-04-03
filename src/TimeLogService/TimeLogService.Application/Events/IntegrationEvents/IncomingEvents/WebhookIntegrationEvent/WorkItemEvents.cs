namespace TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.WebhookIntegrationEvent;

public class WorkItemEvents(ILogger<WorkItemEvents> logger) : IConsumer<AzureWebhookModelEvent<WorkItemResource>>
{
    private readonly ILogger<WorkItemEvents> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<AzureWebhookModelEvent<WorkItemResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}