namespace WebhookService.Contracts.EventModels.SharedModels.EventModels;

public record Fileds(
    [property: JsonProperty(PropertyName = "System.AreaPath", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemAreaPath,

    [property: JsonProperty(PropertyName = "System.TeamProject", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemTeamProject,

    [property: JsonProperty(PropertyName = "System.IterationPath", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemIterationPath,

    [property: JsonProperty(PropertyName = "System.WorkItemType", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemWorkItemType,

    [property: JsonProperty(PropertyName = "System.State", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemState,

    [property: JsonProperty(PropertyName = "System.Reason", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemReason,

    [property: JsonProperty(PropertyName = "System.CreatedDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime SystemCreatedDate,

    [property: JsonProperty(PropertyName = "System.CreatedBy", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemCreatedBy,

    [property: JsonProperty(PropertyName = "System.ChangedDate", NullValueHandling = NullValueHandling.Ignore)]
    DateTime SystemChangedDate,

    [property: JsonProperty(PropertyName = "System.ChangedBy", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemChangedBy,

    [property: JsonProperty(PropertyName = "System.Title", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemTitle,

    [property: JsonProperty(PropertyName = "Microsoft.Azure DevOps Services.Common.Severity", NullValueHandling = NullValueHandling.Ignore)]
    string? Severity,

    [property: JsonProperty(PropertyName = "WEF_EB329F44FE5F4A94ACB1DA153FDF38BA_Kanban.Column", NullValueHandling = NullValueHandling.Ignore)]
    string? KanbanColumn,

    [property: JsonProperty(PropertyName = "System.History", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemHistory);