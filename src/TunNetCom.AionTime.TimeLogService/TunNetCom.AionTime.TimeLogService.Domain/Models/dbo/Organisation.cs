using System;
using System.Collections.Generic;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;



public partial class Organisation : BaseEntity
{
    public string OrganisationName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}



