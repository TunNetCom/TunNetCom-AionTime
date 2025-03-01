using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;

namespace IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;

public record class GeneratePasswordResetTokenCommand(string Email) : IRequest<ApiResponse<PasswordTokenResponse>>;