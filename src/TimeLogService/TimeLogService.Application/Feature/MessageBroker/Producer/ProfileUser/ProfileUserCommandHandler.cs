namespace TimeLogService.Application.Feature.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommandHandler(ISendEndpointProvider sendEndpointProvider) :
IRequestHandler<ProfileUserCommand>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProfileUserCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));
        await endpoint.Send(request.BaseRequest, cancellationToken);
    }
}