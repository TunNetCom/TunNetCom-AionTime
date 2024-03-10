using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;


namespace TunNetCom.AionTime.TimeLogService.Domain.Models;

[Table("Organisation")]


public partial class Organisation : BaseEntity
{
    [StringLength(50)]
    public string OrganisationName { get; set; } = null!;

    [InverseProperty("Organisation")]
    [JsonIgnore]
    public virtual ICollection<Project>?  Projects { get; set; } //= new List<Project>();
}



