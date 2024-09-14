namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WebhookConsumer
{
    public class PipelineEventConsumer(ILogger<PipelineEventConsumer> logger) : IConsumer<AzureWebhookModelEvent<PipeLinesResource>>
    {
        private readonly ILogger<PipelineEventConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<AzureWebhookModelEvent<PipeLinesResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }
    }
}