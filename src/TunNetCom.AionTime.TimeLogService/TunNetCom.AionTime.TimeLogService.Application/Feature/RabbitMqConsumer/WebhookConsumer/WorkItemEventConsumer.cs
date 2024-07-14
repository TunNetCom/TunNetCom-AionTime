using AzureWebhookSharedModels.EventModels.SharedModels;
using AzureWebhookSharedModels.EventModels.SharedModels.ResourcesModels;
using MassTransit;
using Newtonsoft.Json;

namespace TunNetCom.AionTime.TimeLogService.Application.Feature.RabbitMqConsumer.WebhookConsumer;

public class WorkItemEventConsumer : IConsumer<object>
{
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<object> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        string jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
    }
}