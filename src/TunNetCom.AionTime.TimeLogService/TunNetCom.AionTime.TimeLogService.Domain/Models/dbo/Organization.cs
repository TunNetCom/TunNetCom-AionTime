namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

public partial class Organization : BaseEntity
{
    public string OrganizationName { get; set; } = null!;

    public virtual ICollection<Project>? Projects { get; set; } //= new List<Project>();
}