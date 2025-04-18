using System.ComponentModel.DataAnnotations;

namespace TunNetCom.AionTime.SharedKernel.BaseEntites;

public abstract class BaseEntity : IEntity
{
    protected BaseEntity(Guid tenantId)
    {
        TenantId = tenantId;
    }

    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the TenantId is Identity user Id
    /// </summary>
    public Guid TenantId { get; set; }
}