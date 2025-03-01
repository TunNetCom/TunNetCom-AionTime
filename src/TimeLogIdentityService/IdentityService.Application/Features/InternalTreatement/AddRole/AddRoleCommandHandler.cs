
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.AddRole;

namespace IdentityService.Application.Features.InternalTreatement.AddRole;

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