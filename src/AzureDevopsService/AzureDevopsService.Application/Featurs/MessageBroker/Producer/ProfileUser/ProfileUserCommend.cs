using MediatR;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public record class ProfileUserCommend(BaseRequest BaseRequest) : IRequest;