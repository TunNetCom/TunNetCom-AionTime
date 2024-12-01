using AzureDevopsService.Contracts.AzureRequestResourceModel;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.MessageBroker.Producer;

public class ProfileAzureUserCommandHandler(ISendEndpointProvider sendEndpointProvider) : IRequestHandler<ProfileAzureUserCommand>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProfileAzureUserCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));

        BaseRequest azureRequest = new()
        {
            Email = request.Email,
            Path = request.Path,
        };

        await endpoint.Send(azureRequest, cancellationToken);
    }
}