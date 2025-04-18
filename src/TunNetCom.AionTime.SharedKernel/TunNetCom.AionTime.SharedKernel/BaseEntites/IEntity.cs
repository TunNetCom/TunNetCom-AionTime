namespace TunNetCom.AionTime.SharedKernel.BaseEntites;

public interface IEntity
{
    public int Id { get; set; }

    public Guid TenantId { get; protected set; }
}
