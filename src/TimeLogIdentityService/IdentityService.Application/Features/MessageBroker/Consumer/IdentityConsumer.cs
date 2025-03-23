namespace IdentityService.Application.Features.MessageBroker.Consumer
{
    public class IdentityConsumer(ILogger<IdentityConsumer> logger) :
        IConsumer<CustomProblemDetailsResponce>
    {
        private readonly ILogger<IdentityConsumer> _logger = logger;


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }
    }
}