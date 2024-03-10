using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


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



