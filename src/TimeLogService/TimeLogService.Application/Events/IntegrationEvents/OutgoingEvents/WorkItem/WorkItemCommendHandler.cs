namespace TimeLogService.Application.Events.IntegrationEvents.OutgoingEvents.WorkItem;

public class WorkItemCommendHandler(ISendEndpointProvider sendEndpointProvider) : IRequestHandler<WorkItemCommend>
{
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(WorkItemCommend request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/AzureDevops"));
        await endpoint.Send(request.WorkItemRequest, cancellationToken);
    }
}