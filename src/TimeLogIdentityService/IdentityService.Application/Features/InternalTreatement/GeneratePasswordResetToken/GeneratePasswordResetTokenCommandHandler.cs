using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;
using IdentityService.Domain.Models.Dbo;

namespace IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;

public class GeneratePasswordResetTokenCommandHandler(UserManager<ApplicationUser> userManager)
    : IRequestHandler<GeneratePasswordResetTokenCommand, Result<string>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result<string>> Handle(GeneratePasswordResetTokenCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return Result.Fail(ErrorDetails.UserNotFound);
        }

        string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        return Result.Ok(token);
    }
}