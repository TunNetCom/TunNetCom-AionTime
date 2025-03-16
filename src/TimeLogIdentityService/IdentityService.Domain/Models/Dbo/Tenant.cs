namespace IdentityService.Domain.Models.Dbo;

public class Tenant
{
    public Guid Id { get; set; }

    public required string OrganizationName { get; set; }

    public required string OrganizationDescription { get; set; }

    public required string OrganizationAddress { get; set; }

    public string? OrganizationMobilePhone { get; set; }

    public string? OrganizationLandPhone { get; set; }

    public required string OrganizationEmail { get; set; }

    public bool IsActivated { get; set; } = false;

    public virtual ICollection<ApplicationUser>? ApplicationUsers { get; }
}