namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public record class ProfileUserCommand(BaseRequest BaseRequest) : IRequest;