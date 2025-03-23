using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.ChangePassword;

namespace IdentityService.Application.Features.InternalTreatement.ChangePassword
{
    public record class ChangePasswordCommand(string OldPassword, string NewPassword, string Email) : IRequest<Result<IdentityResult>>;
}