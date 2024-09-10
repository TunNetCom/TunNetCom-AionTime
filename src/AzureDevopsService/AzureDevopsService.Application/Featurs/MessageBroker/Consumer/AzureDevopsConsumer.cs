using AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;
using AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource;
using MediatR;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer
{
    public class AzureDevopsConsumer(IMediator mediator) : IConsumer<BaseRequest>, IConsumer<AllProjectUnderOrganizationRequest>
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
    }
}