using AzureDevopsService.Contracts.ExternalRequestModel;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public record class ProfileUserCommand(GetAzureAdminInfoRequest Request) : IRequest;