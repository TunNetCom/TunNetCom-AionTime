using TimeLogService;
using TimeLogService.Domain;
using TimeLogService.Domain.Models;

namespace TimeLogService.Domain.Models.Dbo;

public partial class User : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PublicAlias { get; set; } = null!;

    public int CoreRevision { get; set; }

    public DateTime TimeStamp { get; set; }

    public int Revision { get; set; }

    public virtual ICollection<Organization>? Organizations { get; private set; }
}