using TimeLogService.Application.Feature.UserAction.Commands.AddUser;

namespace TimeLogService.Application.Feature.MessageBroker.Consumer.ProfileUser;

public class ProfileUserConsumer(ILogger<ProfileUserConsumer> logger, IMediator mediator) : IConsumer<UserProfile>, IConsumer<CustomProblemDetailsResponce>
{
    private readonly ILogger<ProfileUserConsumer> _logger = logger;
    private readonly IMediator _mediator = mediator;

    public async Task Consume(ConsumeContext<UserProfile> context)
    {
        await _mediator.Send(new AddUserCommand(context.Message));
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