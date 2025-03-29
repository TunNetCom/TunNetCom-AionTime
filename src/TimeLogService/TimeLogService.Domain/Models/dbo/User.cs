using TimeLogService;
using TimeLogService.Domain;
using TimeLogService.Domain.Models;

namespace TimeLogService.Domain.Models.Dbo;

public partial class User : BaseEntity
{
    public required string UserId { get; set; }

    public required string EmailAddress { get; set; }

    public required string PublicAlias { get; set; }

    public int CoreRevision { get; set; }

    public DateTime TimeStamp { get; set; }

    public int Revision { get; set; }
}