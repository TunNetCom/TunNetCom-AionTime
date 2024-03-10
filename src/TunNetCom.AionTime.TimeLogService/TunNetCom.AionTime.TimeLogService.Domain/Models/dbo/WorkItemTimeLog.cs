namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("WorkItemTimeLog")]


public partial class WorkItemTimeLog : BaseEntity
{
    [StringLength(200)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Time { get; set; }

    public int WorkItemId { get; set; }

    [ForeignKey("WorkItemId")]
    [InverseProperty("WorkItemTimeLogs")]
    [JsonIgnore]
    public virtual WorkItem? WorkItem { get; set; }
}



