namespace TimeLogService.Application.Events.IntegrationEvents.OutgoingEvents.ProfileUser;

public record class ProfileUserCommand(BaseRequest BaseRequest) : IRequest;