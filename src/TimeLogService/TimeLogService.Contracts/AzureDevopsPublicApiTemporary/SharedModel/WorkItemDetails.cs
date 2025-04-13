using Newtonsoft.Json;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.SharedModel
{
    public class WorkItemDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rev")]
        public int Rev { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("relations")]
        public List<Relation> Relations { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Fields
    {
        [JsonProperty("System.Id")]
        public int SystemId { get; set; }

        [JsonProperty("System.AreaId")]
        public int SystemAreaId { get; set; }

        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("System.NodeName")]
        public string SystemNodeName { get; set; }

        [JsonProperty("System.AreaLevel1")]
        public string SystemAreaLevel1 { get; set; }

        [JsonProperty("System.Rev")]
        public int SystemRev { get; set; }

        [JsonProperty("System.AuthorizedDate")]
        public DateTime SystemAuthorizedDate { get; set; }

        [JsonProperty("System.RevisedDate")]
        public DateTime SystemRevisedDate { get; set; }

        [JsonProperty("System.IterationId")]
        public int SystemIterationId { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("System.IterationLevel1")]
        public string SystemIterationLevel1 { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public User SystemAssignedTo { get; set; }

        [JsonProperty("System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public User SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public User SystemChangedBy { get; set; }

        [JsonProperty("System.AuthorizedAs")]
        public User SystemAuthorizedAs { get; set; }

        [JsonProperty("System.PersonId")]
        public int SystemPersonId { get; set; }

        [JsonProperty("System.Watermark")]
        public int SystemWatermark { get; set; }

        [JsonProperty("System.CommentCount")]
        public int SystemCommentCount { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("System.BoardColumn")]
        public string SystemBoardColumn { get; set; }

        [JsonProperty("System.BoardColumnDone")]
        public bool SystemBoardColumnDone { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime MicrosoftStateChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int MicrosoftPriority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.ValueArea")]
        public string MicrosoftValueArea { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.BacklogPriority")]
        public long MicrosoftBacklogPriority { get; set; }

        [JsonProperty("WEF_1B6E3DE9531245B09486D065F70CDD95_System.ExtensionMarker")]
        public bool WefExtensionMarker { get; set; }

        [JsonProperty("WEF_1B6E3DE9531245B09486D065F70CDD95_Kanban.Column")]
        public string WefKanbanColumn { get; set; }

        [JsonProperty("WEF_1B6E3DE9531245B09486D065F70CDD95_Kanban.Column.Done")]
        public bool WefKanbanColumnDone { get; set; }
    }

    public class User
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("_links")]
        public UserLinks Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }

    public class UserLinks
    {
        [JsonProperty("avatar")]
        public Link Avatar { get; set; }
    }

    public class Relation
    {
        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Links
    {
        [JsonProperty("self")]
        public Link Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public Link WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions")]
        public Link WorkItemRevisions { get; set; }

        [JsonProperty("workItemComments")]
        public Link WorkItemComments { get; set; }

        [JsonProperty("html")]
        public Link Html { get; set; }

        [JsonProperty("workItemType")]
        public Link WorkItemType { get; set; }

        [JsonProperty("fields")]
        public Link Fields { get; set; }
    }

    public class Link
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

}
