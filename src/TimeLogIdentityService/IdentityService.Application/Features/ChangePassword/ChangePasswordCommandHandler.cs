using IdentityService.Contracts.Constant;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.ChangePassword
{
    public class ChangePasswordCommandHandler(UserManager<IdentityUser> userManager) :
        IRequestHandler<ChangePasswordCommand, ApiResponse>
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<ApiResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new ApiResponse()
                {
                    Succeeded = false,
                    Error = new ProblemDetails()
                    {
                        Title = nameof(ErrorDetails.InvalidEmail),
                        Detail = ErrorDetails.InvalidEmail,
                        Status = 404,
                    },
                };
            }

            if (!await _userManager.CheckPasswordAsync(user, request.OldPassword))
            {
                return new ApiResponse()
                {
                    Succeeded = false,
                    Error = new ProblemDetails()
                    {
                        Title = nameof(ErrorDetails.InvalidOldPassword),
                        Detail = ErrorDetails.InvalidOldPassword,
                        Status = 400,
                    },
                };
            }

            _ = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
            return new ApiResponse()
            {
                Succeeded = false,
            };
        }
    }
}