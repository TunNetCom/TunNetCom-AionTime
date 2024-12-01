using IdentityService.Application.Features.RedeemRecoveryCode;
using IdentityService.Domain.Models.Dbo;

namespace IdentityService.Application.Features.GeneratePasswordResetToken;

public class GeneratePasswordResetTokenCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<GeneratePasswordResetTokenCommand, ApiResponse<PasswordTokenResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<ApiResponse<PasswordTokenResponse>> Handle(GeneratePasswordResetTokenCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            return new ApiResponse<PasswordTokenResponse>()
            {
                Succeeded = false,
                Error = new()
                {
                    Status = 400,
                    Detail = $"User {request.Email} not found",
                    Title = "User not found",
                },
            };
        }

        string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        return new ApiResponse<PasswordTokenResponse>()
        {
            Succeeded = true,
            Data = new PasswordTokenResponse()
            {
                Token = token,
            },
        };
    }
}