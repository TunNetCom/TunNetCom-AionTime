#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.AddRole
{
    public record class AddRoleCommand(string RoleName) : IRequest<IdentityResult>;
}