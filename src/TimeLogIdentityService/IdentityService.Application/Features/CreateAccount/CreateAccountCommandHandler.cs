#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.CreateAccount;

public class CreateAccountCommandHandler(UserManager<IdentityUser> userManager)
    : IRequestHandler<CreateAccountCommand, IdentityResult>
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<IdentityResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        IdentityUser user = new()
        {
            UserName = request.Username,
            Email = request.Email,
            EmailConfirmed = request.ConfirmedEmail,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        return result;
    }
}