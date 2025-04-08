namespace IdentityService.Application.Features.InternalTreatement.ChangePassword
{
    public record class ChangePasswordCommand(string OldPassword, string NewPassword, string Email) : IRequest<Result<IdentityResult>>;
}