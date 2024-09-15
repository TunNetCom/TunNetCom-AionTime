namespace TimeLogService.Domain.Models;

public partial class User : BaseEntity
{
    public string UserId { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PublicAlias { get; set; } = null!;

    public int CoreRevision { get; set; }

    public DateTime TimeStamp { get; set; }

    public int Revision { get; set; }

    public virtual ICollection<Organization>?  Organizations { get; set; } //= new List<Organization>();
}