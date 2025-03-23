namespace IdentityService.Application.Features.InternalTreatement.AddTenant;

public record class AddTenantCommand(
    string Name,
    string Email,
    string Address,
    string LandPhone,
    string MobilePhone,
    string Description) : IRequest<Result<Guid>>;