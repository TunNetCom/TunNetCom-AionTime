#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.AttachUserToRole;

namespace IdentityService.Application.Features.InternalTreatement.AttachUserToRole
{
    public record class AttachUserToRoleCommand(string Email, string Role) : IRequest<ApiResponse<UserToRoleResponse>>;
}