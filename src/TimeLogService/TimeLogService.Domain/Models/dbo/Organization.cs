namespace TimeLogService.Domain.Models.Dbo;

public partial class Organization : BaseEntity
{
    public Organization(Guid tenantId) : base(tenantId)
    {
    }

    public required string Name { get; set; }

    public bool IsAionTimeApproved { get; set; }

    public virtual ICollection<Project>? Projects { get; private set; }
}