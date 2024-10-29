#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.ChangePassword
{
    public record class ChangePasswordCommand(string OldPassword, string NewPassword, string Email) : IRequest<ApiResponse>;
}