#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using IdentityService;
using IdentityService.Application;
using IdentityService.Application.Features;
using IdentityService.Application.Features.InternalTreatement.Login;

namespace IdentityService.Application.Features.InternalTreatement.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<ApiResponse<LoginResponse>>;
}