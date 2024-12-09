using AzureDevopsService.Contracts.AzureRequestModel;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public record class ProfileUserCommand(AzureAdminInfoRequest Request) : IRequest;