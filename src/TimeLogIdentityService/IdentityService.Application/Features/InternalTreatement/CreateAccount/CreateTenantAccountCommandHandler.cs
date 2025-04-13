using IdentityService.Application.Events.DomainEvents.Events;
using IdentityService.Application.Events.IntegrationEvents.Events.Outgoing;
using MediatR;
using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

namespace IdentityService.Application.Features.InternalTreatement.CreateAccount;

public class CreateTenantAccountCommandHandler(UserManager<ApplicationUser> userManager, IMediator mediator, IEventBus eventBus)
    : IRequestHandler<CreateTenantAccountCommand, Result<IdentityResult>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IMediator _mediator = mediator;

    public async Task<Result<IdentityResult>> Handle(CreateTenantAccountCommand request, CancellationToken cancellationToken)
    {
        Result<Guid> tenant = await _mediator.Send(new AddTenantCommand(
            request.OrganizationName,
            request.OrganizationEmail,
            request.OrganizationAdress,
            request.OrganizationLandPhone,
            request.OrganizationMobilePhone,
            request.OrganizationDescription));

        if (!tenant.IsSuccess)
        {
            return Result.Fail(tenant.Errors);
        }

        ApplicationUser user = new()
        {
            UserName = request.Username,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            EmailConfirmed = request.ConfirmedEmail,
            SecurityStamp = Guid.NewGuid().ToString(),
            TenantId = tenant.Value,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            //await _mediator.Publish(new TenantCreatedDomainEvent(tenant.Value, request.AzureDevopsPath, string.Empty, request.Email), cancellationToken);
            TenantCreatedIntegrationEvent retriveUserOrganizationIntegrationEvent = new(request.Email, request.AzureDevopsPath, tenant.Value);
            await eventBus.PublishAsync(retriveUserOrganizationIntegrationEvent);
        }

        return Result.Ok(result);
    }
}