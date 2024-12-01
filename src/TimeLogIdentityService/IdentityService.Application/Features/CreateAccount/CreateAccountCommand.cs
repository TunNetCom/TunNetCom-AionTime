#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.CreateAccount;

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