using AzureDevopsService.Contracts.AzureRequestResourceModel;
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.CreateAccount;
using IdentityService.Application.Features.MessageBroker.Producer;
using IdentityService.Domain.Models.Dbo;
using MassTransit;
using MassTransit.Transports;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.InternalTreatement.CreateAccount;

public class CreateAccountCommandHandler(UserManager<ApplicationUser> userManager, IMediator mediator)
    : IRequestHandler<CreateAccountCommand, IdentityResult>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IMediator _mediator = mediator;

    public async Task<IdentityResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser user = new()
        {
            UserName = request.Username,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            EmailConfirmed = request.ConfirmedEmail,
            SecurityStamp = Guid.NewGuid().ToString(),
            IsPrincipalAccount = true,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _mediator.Send(new ProfileAzureUserCommand(request.Email, request.AzureKey), cancellationToken);
        }

        return result;
    }
}