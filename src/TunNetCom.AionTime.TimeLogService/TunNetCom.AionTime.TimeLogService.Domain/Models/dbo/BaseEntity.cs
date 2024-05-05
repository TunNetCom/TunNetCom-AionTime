using MediatR;

namespace TunNetCom.AionTime.TimeLogService.Domain.Models.dbo;

public partial class BaseEntity : IRequest<int>
{
    [Key]
    public int Id { get; set; }
}
