namespace TimeLogService.Contracts.DTOs.Request;

public class WorkItemTimeLogRequest
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime? Time { get; set; }

    public int WorkItemId { get; set; }
}