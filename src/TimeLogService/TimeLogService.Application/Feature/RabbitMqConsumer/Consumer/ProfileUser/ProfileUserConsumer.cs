using AzureDevopsService.Contracts.AzureResponceModel;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.ProfileUser
{
    public class ProfileUserConsumer : IConsumer<UserAccount>, IConsumer<CustomProblemDetailsResponce>
    {
#pragma warning disable format
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<UserAccount> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
            Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }

#pragma warning disable format
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            string jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"AzureWebhookModelEvent message: {jsonMessage}");
        }
    }
}