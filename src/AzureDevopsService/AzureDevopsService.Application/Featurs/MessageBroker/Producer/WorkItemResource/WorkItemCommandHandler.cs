namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.WorkItemResource;

public class WorkItemCommandHandler(IWorkItemExternalService workItemExternalService, ISendEndpointProvider sendEndpointProvider) : IRequestHandler<WorkItemCommand>
{
    private readonly IWorkItemExternalService _workItemExternalService = workItemExternalService;
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(WorkItemCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/WorkItemResponce"));

        OneOf<WiqlResponses?, WiqlBadRequestResponce?> workItemResponse = await _workItemExternalService.GetWorkItemByUser(request.WorkItemRequest);

        if (workItemResponse.IsT0)
        {
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            await endpoint.Send(workItemResponse.AsT0, cancellationToken);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        }
        else
        {
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            await endpoint.Send(workItemResponse.AsT1, cancellationToken);
        }
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
    }
}