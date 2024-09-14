namespace TimeLogService.Application.Feature.MessageBroker.Producer.ProfileUser;

public record class ProfileUserCommand(BaseRequest BaseRequest) : IRequest;