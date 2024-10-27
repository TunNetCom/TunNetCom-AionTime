#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Application.Features.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<ApiResponse<LoginResponse>>;
}