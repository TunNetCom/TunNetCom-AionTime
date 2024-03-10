

using System.ComponentModel.DataAnnotations;

namespace TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;

public partial class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
