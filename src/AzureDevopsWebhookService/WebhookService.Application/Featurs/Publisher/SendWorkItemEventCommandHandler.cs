//namespace WebhookService.Application.Featurs.Publisher;

//public class SendWorkItemEventCommandHandler(ISendEndpointProvider sendEndpointProvider)
//: IRequestHandler<AzureWebhookModelEvent<WorkItemResource>>
//{
//    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

//    public async Task Handle(
//        AzureWebhookModelEvent<WorkItemResource> request,
//        CancellationToken cancellationToken)
//    {
//        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/WorkItemEvent"));
//        await endpoint.Send(request, cancellationToken);
//    }
//}