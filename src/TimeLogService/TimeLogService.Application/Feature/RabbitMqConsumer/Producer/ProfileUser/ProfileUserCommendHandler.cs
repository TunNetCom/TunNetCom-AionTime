using AzureDevopsService.Contracts.AzureResponceModel;
using OneOf;
using System.Threading;
using System.Threading.Tasks;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.ProfileUser
{
    public class ProfileUserCommendHandler(ISendEndpointProvider sendEndpointProvider) :
    IRequestHandler<ProfileUserCommend>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

        public async Task Handle(ProfileUserCommend request, CancellationToken cancellationToken)
        {
            ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProfileUser"));
            await endpoint.Send(request.BaseRequest, cancellationToken);
        }
    }
}