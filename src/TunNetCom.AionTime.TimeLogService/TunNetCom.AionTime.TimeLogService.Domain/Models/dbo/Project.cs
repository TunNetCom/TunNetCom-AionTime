namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("Project")]


public partial class Project : BaseEntity
{
    public int OrganisationId { get; set; }

    [ForeignKey("OrganisationId")]
    [InverseProperty("Projects")]
    [JsonIgnore]
    public virtual Organisation? Organisation { get; set; }

    [InverseProperty("Project")]
    [JsonIgnore]
    public virtual ICollection<WorkItem>?  WorkItems { get; set; } //= new List<WorkItem>();
}



