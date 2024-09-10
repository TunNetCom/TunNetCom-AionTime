namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.ProfileUser;

public record class ProfileUserCommand(BaseRequest BaseRequest) : IRequest;