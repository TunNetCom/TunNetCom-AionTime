namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

public partial class Organisation : BaseEntity
{
    public string OrganisationName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Project>? Projects { get; set; }
}