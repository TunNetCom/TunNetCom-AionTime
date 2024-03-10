using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


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



