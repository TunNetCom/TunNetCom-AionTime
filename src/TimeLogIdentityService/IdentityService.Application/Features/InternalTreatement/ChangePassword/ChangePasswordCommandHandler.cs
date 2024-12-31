using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.ChangePassword;
using IdentityService.Contracts.Constant;
using IdentityService.Domain.Models.Dbo;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.InternalTreatement.ChangePassword
{
    public class ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager) :
        IRequestHandler<ChangePasswordCommand, ApiResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<ApiResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(request.Email);
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