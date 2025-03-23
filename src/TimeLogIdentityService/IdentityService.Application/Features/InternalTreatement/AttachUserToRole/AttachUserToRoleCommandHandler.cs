namespace IdentityService.Application.Features.InternalTreatement.AttachUserToRole;

public class AttachUserToRoleCommandHandler(UserManager<ApplicationUser> userManager) :
    IRequestHandler<AttachUserToRoleCommand, Result<IdentityResult>>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<Result<IdentityResult>> Handle(
        AttachUserToRoleCommand request,
        CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return Result.Fail(ErrorDetails.RoleNotFound);
        }

        IdentityResult result = await _userManager.AddToRoleAsync(user, request.Role);
        if (!result.Succeeded)
        {
            return Result.Fail(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        return Result.Ok(result);
    }
}