namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.Project;

public class ProjectCommandHandler(ISendEndpointProvider sendEndpointProvider) : IRequestHandler<ProjectCommand>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProjectCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));
        await endpoint.Send(request.Request, cancellationToken);
    }
}