using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.Project
{
    public class ProjectConsumer : IConsumer<AllProjectResponce>, IConsumer<CustomProblemDetailsResponce>
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<AllProjectResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }
    }
}