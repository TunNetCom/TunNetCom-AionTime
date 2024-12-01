namespace IdentityService.Application.Features.RedeemRecoveryCode;

public record class GeneratePasswordResetTokenCommand(string Email) : IRequest<ApiResponse<PasswordTokenResponse>>;