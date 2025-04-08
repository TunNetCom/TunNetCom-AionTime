namespace IdentityService.Application.Features.InternalTreatement.AttachUserToRole
{
    public record class AttachUserToRoleCommand(string Email, string Role) : IRequest<Result<IdentityResult>>;
}