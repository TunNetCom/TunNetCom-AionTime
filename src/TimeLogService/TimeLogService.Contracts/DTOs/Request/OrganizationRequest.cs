namespace TimeLogService.Contracts.DTOs.Request;

public class OrganizationRequest
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}