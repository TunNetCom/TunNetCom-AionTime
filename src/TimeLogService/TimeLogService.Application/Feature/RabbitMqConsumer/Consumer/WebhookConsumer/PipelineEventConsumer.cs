﻿using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Feature;
using TimeLogService.Application.Feature.RabbitMqConsumer;
using TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WebhookConsumer;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.WebhookConsumer
{
    public class PipelineEventConsumer : IConsumer<AzureWebhookModelEvent<PipeLinesResource>>
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<AzureWebhookModelEvent<PipeLinesResource>> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"PipelineEvent message: {jsonMessage}");
        }
    }
}