namespace TimeLogService.Domain.Models.dbo;

public class WorkItemComment : BaseEntity
{
    public int WorkItemId { get; set; }
    public int AzureWorkItemId { get; set; }
    public long AzureCommentId { get; set; }

    public int Version { get; set; }
    public string? CommentText { get; set; }

    public Uri CommentUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedByUserDisplayName { get; set; }
    public string CommentFormat { get; set; } = string.Empty;
    public string? CreatedByUserEmail { get; set; }
    public string? CreatedByUserId { get; set; }

    public virtual WorkItem? WorkItem { get; set; }
}
