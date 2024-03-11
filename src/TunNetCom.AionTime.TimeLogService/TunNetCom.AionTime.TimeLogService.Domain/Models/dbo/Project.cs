using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;



public partial class Project : BaseEntity
{
    public int OrganisationId { get; set; }

    [JsonIgnore]
    public virtual Organisation? Organisation { get; set; }

    [JsonIgnore]
    public virtual ICollection<WorkItem>?  WorkItems { get; set; } //= new List<WorkItem>();
}



