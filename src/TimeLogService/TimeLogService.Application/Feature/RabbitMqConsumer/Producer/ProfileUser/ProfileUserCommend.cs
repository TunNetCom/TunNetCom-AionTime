using AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.ProfileUser;

public record class ProfileUserCommend(BaseRequest BaseRequest) : IRequest;