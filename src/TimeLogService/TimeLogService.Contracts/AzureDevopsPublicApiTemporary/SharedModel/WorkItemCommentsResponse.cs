using Newtonsoft.Json;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.SharedModel;

public class WorkItemCommentsResponse
{
    public int TotalCount { get; set; }
    public int Count { get; set; }
    public List<Comment> Comments { get; set; }
}

public class Comment
{
    public List<Mention> Mentions { get; set; }
    public int WorkItemId { get; set; }
    public long Id { get; set; }
    public int Version { get; set; }
    public string Text { get; set; }
    public CommentUser CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public CommentUser ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string Format { get; set; }
    public string RenderedText { get; set; }
    public string Url { get; set; }
}

public class Mention
{
    public string ArtifactId { get; set; }
    public string ArtifactType { get; set; }
    public long CommentId { get; set; }
    public string TargetId { get; set; }
}

public class CommentUser
{
    public string DisplayName { get; set; }
    public string Url { get; set; }
    [JsonProperty("_links")]
    public CommentLinks Links { get; set; }
    public string Id { get; set; }
    public string UniqueName { get; set; }
    public string ImageUrl { get; set; }
    public string Descriptor { get; set; }
}

public class CommentLinks
{
    public Avatar Avatar { get; set; }
}

public class Avatar
{
    public string Href { get; set; }
}
