#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.AddRole;

public class AddRoleCommandHandler(RoleManager<IdentityRole> roleManager)
    : IRequestHandler<AddRoleCommand, IdentityResult>
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<IdentityResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        IdentityRole roleToCreate = new IdentityRole()
        {
            Name = request.RoleName,
        };
        IdentityResult roleResult = await _roleManager.CreateAsync(roleToCreate);
        return roleResult;
    }
}