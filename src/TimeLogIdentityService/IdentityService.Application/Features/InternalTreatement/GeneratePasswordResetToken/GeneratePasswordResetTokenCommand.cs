namespace IdentityService.Application.Features.InternalTreatement.GeneratePasswordResetToken;

public record class GeneratePasswordResetTokenCommand(string Email) : IRequest<Result<string>>;