namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer;

public class AzureDevopsConsumer(IMediator mediator, ILogger<AzureDevopsConsumer> logger) :
    IConsumer<BaseRequest>,
    IConsumer<AllProjectUnderOrganizationRequest>,
    IConsumer<WorkItemRequest>
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<AzureDevopsConsumer> _logger = logger;

    public async Task Consume(ConsumeContext<BaseRequest> context)
    {
        _logger.LogInformation("ProfileUserCommandHandler triggered with request: {context}", context);

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