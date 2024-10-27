#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.AttachUserToRole
{
    public record class AttachUserToRoleCommand(string Email, string Role) : IRequest<ApiResponse<UserToRoleResponse>>;
}