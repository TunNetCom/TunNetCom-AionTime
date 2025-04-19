namespace TimeLogService.Domain.Entites;

public partial class Organization : BaseEntity
{
    private Organization(Guid tenantId, string name) : base(tenantId)
    {
        Name = name;
    }

    public static Organization Create(Guid tenantId, string name)
    {
        return new Organization(tenantId: tenantId, name: name);
    }

    public string Name { get; private set; }

    public virtual ICollection<Project>? Projects { get; private set; }
}