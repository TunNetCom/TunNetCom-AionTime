#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.AddRole;

namespace IdentityService.Application.Features.InternalTreatement.AddRole
{
    public record class AddRoleCommand(string RoleName) : IRequest<IdentityResult>;
}