using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("WorkItemHistory")]


public partial class WorkItemHistory : BaseEntity
{
    [StringLength(1000)]
    [Unicode(false)]
    public string? History { get; set; }

    public int WorkItemId { get; set; }

    [ForeignKey("WorkItemId")]
    [InverseProperty("WorkItemHistories")]
    [JsonIgnore]
    public virtual WorkItem? WorkItem { get; set; }
}



