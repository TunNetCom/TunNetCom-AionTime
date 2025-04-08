namespace IdentityService.Application.Features.InternalTreatement.AddRole
{
    public record class AddRoleCommand(string RoleName) : IRequest<IdentityResult>;
}