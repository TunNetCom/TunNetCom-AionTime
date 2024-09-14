namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer
{
    public class AzureDevopsConsumer(IMediator mediator) : IConsumer<BaseRequest>, IConsumer<AllProjectUnderOrganizationRequest>, IConsumer<WorkItemRequest>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Consume(ConsumeContext<BaseRequest> context)
        {
            await _mediator.Send(new ProfileUserCommand(context.Message));
        }

        public async Task Consume(ConsumeContext<AllProjectUnderOrganizationRequest> context)
        {
            await _mediator.Send(new ProjectCommand(context.Message));
        }

        public async Task Consume(ConsumeContext<WorkItemRequest> context)
        {
            await _mediator.Send(new WorkItemCommand(context.Message));
        }
    }
}