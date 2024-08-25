namespace TimeLogService.Contracts.DTOs.Request;

public class WorkItemHistoryRequest
{
    public int Id { get; set; }

    public string? History { get; set; }

    public int WorkItemId { get; set; }
}