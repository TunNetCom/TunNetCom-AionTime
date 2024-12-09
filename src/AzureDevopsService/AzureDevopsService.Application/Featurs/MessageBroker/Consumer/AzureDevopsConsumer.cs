using AzureDevopsService.Contracts.AzureRequestModel;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer;

public class AzureDevopsConsumer(IMediator mediator, ILogger<AzureDevopsConsumer> logger) :
    IConsumer<AzureAdminInfoRequest>,
    IConsumer<AllProjectUnderOrganizationRequest>,
    IConsumer<WorkItemRequest>
{
    private readonly IMediator _mediator = mediator;
    private readonly ILogger<AzureDevopsConsumer> _logger = logger;

    public async Task Consume(ConsumeContext<AzureAdminInfoRequest> context)
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