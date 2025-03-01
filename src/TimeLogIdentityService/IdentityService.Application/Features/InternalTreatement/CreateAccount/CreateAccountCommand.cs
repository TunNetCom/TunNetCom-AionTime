using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.CreateAccount;

namespace IdentityService.Application.Features.InternalTreatement.CreateAccount;

public record class CreateAccountCommand(
    string Username,
    string Name,
    string LastName,
    string Email,
    bool ConfirmedEmail,
    string Password,
    string ConfirmPassword,
    string AzureKey,
    string GitHubKey) : IRequest<IdentityResult>;