namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WorkItem
{
    internal class WorkItemConsumer : IConsumer<WiqlResponses>, IConsumer<WiqlBadRequestResponce>
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<WiqlResponses> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<WiqlBadRequestResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }
    }
}