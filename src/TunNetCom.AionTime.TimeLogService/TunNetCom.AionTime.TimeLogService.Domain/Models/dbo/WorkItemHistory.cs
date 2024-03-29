﻿namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

public partial class WorkItemHistory : BaseEntity
{
    public string? History { get; set; }

    public int WorkItemId { get; set; }

    [JsonIgnore]
    public virtual WorkItem? WorkItem { get; set; }
}