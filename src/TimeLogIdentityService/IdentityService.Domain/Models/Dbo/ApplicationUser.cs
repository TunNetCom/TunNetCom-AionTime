namespace IdentityService.Domain.Models.Dbo;

public class ApplicationUser : IdentityUser
{
    public required string Name { get; set; }

    public required string LastName { get; set; }

    public required Guid TenantId { get; set; }

    public Tenant? Tenant { get; }
}