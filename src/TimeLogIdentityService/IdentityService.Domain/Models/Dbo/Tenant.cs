namespace IdentityService.Domain.Models.Dbo;

public class Tenant
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Address { get; set; }

    public string? MobilePhone { get; set; }

    public string? LandPhone { get; set; }

    public required string Email { get; set; }

    public bool IsActivated { get; set; } = false;

    public virtual ICollection<ApplicationUser>? ApplicationUsers { get; }
}