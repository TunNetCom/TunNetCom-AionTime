using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.CreateAccount;
using OneOf;

namespace IdentityService.Application.Features.InternalTreatement.CreateAccount;

public record class CreateTenantAccountCommand(
    string Username,
    string Name,
    string LastName,
    string Email,
    bool ConfirmedEmail,
    string Password,
    string ConfirmPassword,
    string AzureDevopsPath,
    string OrganizationName,
    string OrganizationEmail,
    string OrganizationAdress,
    string OrganizationLandPhone,
    string OrganizationMobilePhone,
    string OrganizationDescription) : IRequest<OneOf<IdentityResult, ProblemDetails>>;