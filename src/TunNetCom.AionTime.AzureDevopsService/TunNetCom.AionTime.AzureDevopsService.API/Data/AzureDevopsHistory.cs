namespace TunNetCom.AionTime.AzureDevopsService.API.Data;

public partial class AzureDevopsHistory
{
    public int Id { get; set; }

    public int? ActionType { get; set; }

    public string? Email { get; set; }

    public DateOnly? ActionDate { get; set; }
}