using AzureDevopsService.Contracts.AzureRequestResourceModel;
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.AddTenant;
using IdentityService.Application.Features.InternalTreatement.CreateAccount;
using IdentityService.Application.Features.InternalTreatement.Events.TenatCreated;
using IdentityService.Application.Features.MessageBroker.Producer;
using IdentityService.Domain.Models.Dbo;
using MassTransit;
using MassTransit.Transports;
using OneOf;

namespace IdentityService.Application.Features.InternalTreatement.CreateAccount;

public class CreateTenantAccountCommandHandler(UserManager<ApplicationUser> userManager, IMediator mediator)
    : IRequestHandler<CreateTenantAccountCommand, OneOf<IdentityResult, ProblemDetails>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IMediator _mediator = mediator;

    public async Task<OneOf<IdentityResult, ProblemDetails>> Handle(CreateTenantAccountCommand request, CancellationToken cancellationToken)
    {
        OneOf<Guid, ProblemDetails> tenant = await _mediator.Send(new AddTenantCommand(
            request.OrganizationName,
            request.OrganizationEmail,
            request.OrganizationAdress,
            request.OrganizationLandPhone,
            request.OrganizationMobilePhone,
            request.OrganizationDescription));

        if (tenant.IsT1)
        {
            return tenant.AsT1;
        }

        ApplicationUser user = new()
        {
            UserName = request.Username,
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            EmailConfirmed = request.ConfirmedEmail,
            SecurityStamp = Guid.NewGuid().ToString(),
            TenantId = tenant.AsT0,
        };

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _mediator.Publish(new TenantCreatedNotification(tenant.AsT0, request.AzureDevopsPath, string.Empty, request.Email), cancellationToken);
        }

        return result;
    }
}