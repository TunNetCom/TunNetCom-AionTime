using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;



public partial class WorkItemHistory : BaseEntity
{
    public string? History { get; set; }

    public int WorkItemId { get; set; }

    public virtual WorkItem? WorkItem { get; set; }
}