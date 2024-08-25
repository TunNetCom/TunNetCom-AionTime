namespace TimeLogService.Contracts.DTOs.Request;

public class WorkItemRequest
{
    public int Id { get; set; }

    public string? Discription { get; set; }

    public int ProjectId { get; set; }
}