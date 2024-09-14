namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.Project
{
    public class ProjectConsumer(ILogger<ProjectConsumer> logger) : IConsumer<AllProjectResponce>, IConsumer<CustomProblemDetailsResponce>
    {
        private readonly ILogger<ProjectConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<AllProjectResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }
    }
}