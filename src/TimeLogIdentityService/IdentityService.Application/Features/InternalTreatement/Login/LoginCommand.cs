namespace IdentityService.Application.Features.InternalTreatement.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<Result<LoginResponse>>;
}