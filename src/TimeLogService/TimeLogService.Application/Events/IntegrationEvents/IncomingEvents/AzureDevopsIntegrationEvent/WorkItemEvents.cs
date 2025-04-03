namespace TimeLogService.Application.Events.IntegrationEvents.IncomingEvents.AzureDevopsIntegrationEvent;

internal class WorkItemEvent(ILogger<WorkItemEvent> logger) : IConsumer<WiqlResponses>, IConsumer<WiqlBadRequestResponce>
{
    private readonly ILogger<WorkItemEvent> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<WiqlResponses> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<WiqlBadRequestResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}