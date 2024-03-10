using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;



public partial class WorkItemTimeLog : BaseEntity
{
    public string? Description { get; set; }

    public DateOnly? Time { get; set; }

    public int WorkItemId { get; set; }

    public virtual WorkItem WorkItem { get; set; } = null!;
}



