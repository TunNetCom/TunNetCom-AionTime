namespace TimeLogService.Application.Feature.RabbitMqConsumer.Consumer.ProfileUser
{
    public class ProfileUserConsumer(ILogger<ProfileUserConsumer> logger) : IConsumer<UserAccount>, IConsumer<CustomProblemDetailsResponce>
    {
        private readonly ILogger<ProfileUserConsumer> _logger = logger;

#pragma warning disable format
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<UserAccount> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }

#pragma warning disable format
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }
    }
}