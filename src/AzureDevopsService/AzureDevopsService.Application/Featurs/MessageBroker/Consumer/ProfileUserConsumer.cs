using AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;
using MediatR;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Consumer
{
    public class ProfileUserConsumer(IMediator mediator) : IConsumer<BaseRequest>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Consume(ConsumeContext<BaseRequest> context)
        {
            await _mediator.Send(new ProfileUserCommend(context.Message));
        }
    }
}