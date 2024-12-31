using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;

public record class GeneratePasswordResetTokenCommand(string Email) : IRequest<ApiResponse<PasswordTokenResponse>>;