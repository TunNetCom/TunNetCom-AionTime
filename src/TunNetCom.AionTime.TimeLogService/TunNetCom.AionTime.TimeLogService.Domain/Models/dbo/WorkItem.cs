using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;



public partial class WorkItem : BaseEntity
{
    public string? Discription { get; set; }

    public int ProjectId { get; set; }

    [JsonIgnore]
    public virtual Project? Project { get; set; }

    [JsonIgnore]
    public virtual ICollection<WorkItemHistory>?  WorkItemHistories { get; set; } //= new List<WorkItemHistory>();

    [JsonIgnore]
    public virtual ICollection<WorkItemTimeLog>?  WorkItemTimeLogs { get; set; } //= new List<WorkItemTimeLog>();
}



