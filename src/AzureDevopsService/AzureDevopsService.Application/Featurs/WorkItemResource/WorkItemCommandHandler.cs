//using AzureDevopsService.Contracts.Internal.Interfaces;

//namespace AzureDevopsService.Application.Featurs.WorkItemResource;

//public class WorkItemCommandHandler(
//    IWorkItemExternalService workItemExternalService,
//    ISendEndpointProvider sendEndpointProvider)
//    : IRequestHandler<WorkItemCommand>
//{
//    private readonly IWorkItemExternalService _workItemExternalService = workItemExternalService;
//    //private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

//    public async Task Handle(WorkItemCommand request, CancellationToken cancellationToken)
//    {
//        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(
//            new Uri("rabbitmq://rabbitmq/WorkItemResponce"));

//        OneOf<WiqlResponses, WiqlBadRequestResponce> workItemResponse = 
//            await _workItemExternalService.GetWorkItemByUser(request.WorkItemRequest);

//        if (workItemResponse.IsT0)
//        {
//            await endpoint.Send(workItemResponse.AsT0, cancellationToken);
//        }
//        else
//        {
//            await endpoint.Send(workItemResponse.AsT1, cancellationToken);
//        }
//    }
//}