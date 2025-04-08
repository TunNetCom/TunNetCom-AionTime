//namespace WebhookService.Application.Featurs.Producer;

//public class SendAzureCodeEventsCommandHandler(ISendEndpointProvider sendEndpointProvider)
//: IRequestHandler<AzureWebhookModelEvent<CodeResource>>
//{
//    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

//    public async Task Handle(
//        AzureWebhookModelEvent<CodeResource> request,
//        CancellationToken cancellationToken)
//    {
//        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/CodeEvents"));
//        await endpoint.Send(request, cancellationToken);
//    }
//}