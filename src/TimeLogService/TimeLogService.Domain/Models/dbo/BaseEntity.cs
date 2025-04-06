namespace TimeLogService.Domain.Models.Dbo;

public abstract partial class BaseEntity : IRequest<int>
{
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the TenantId is Identity user Id
    /// </summary>
    public required string TenantId { get; set; }
}