namespace IdentityService.Application.Features.InternalTreatement.ChangePassword
{
    public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager) :
        IRequestHandler<ChangePasswordCommand, Result<IdentityResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<Result<IdentityResult>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return Result.Fail(ErrorDetails.InvalidEmail);
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            return Result.Ok(result);
        }
    }
}