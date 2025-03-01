namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer;

public class AzureDevopsConsumer(IMediator mediator, ILogger<AzureDevopsConsumer> logger) :
    IConsumer<AzureAdminInfoRequest>,
    IConsumer<GetOrganizationProjectsRequest>,
    IConsumer<WorkItemRequest>,
    IConsumer<CreateWebhookRequest>
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<AzureDevopsConsumer> _logger = logger;

    public async Task Consume(ConsumeContext<AzureAdminInfoRequest> context)
    {
        _logger.LogInformation("ProfileUserCommandHandler triggered with request: {context}", context);

        await _mediator.Send(new ProfileUserCommand(context.Message));
    }

    public async Task Consume(ConsumeContext<GetOrganizationProjectsRequest> context)
    {
        await _mediator.Send(new ProjectCommand(context.Message));
    }

    public async Task Consume(ConsumeContext<WorkItemRequest> context)
    {
        await _mediator.Send(new WorkItemCommand(context.Message));
    }

    public async Task Consume(ConsumeContext<CreateWebhookRequest> context)
    {
        await _mediator.Send(new CreateWebhookCommand(context.Message));
    }
}