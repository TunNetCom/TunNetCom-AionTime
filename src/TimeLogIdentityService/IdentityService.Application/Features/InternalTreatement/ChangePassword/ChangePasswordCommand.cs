#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.ChangePassword;

namespace IdentityService.Application.Features.InternalTreatement.ChangePassword
{
    public record class ChangePasswordCommand(string OldPassword, string NewPassword, string Email) : IRequest<ApiResponse>;
}