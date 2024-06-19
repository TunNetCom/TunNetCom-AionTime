using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels
{
    public class Fileds
    {
        [JsonProperty("System.AreaPath", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemTeamProject { get; set; }

        [JsonProperty("System.IterationPath", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemIterationPath { get; set; }

        [JsonProperty("System.WorkItemType", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemWorkItemType { get; set; }

        [JsonProperty("System.State", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemState { get; set; }

        [JsonProperty("System.Reason", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemReason { get; set; }

        [JsonProperty("System.CreatedDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemChangedBy { get; set; }

        [JsonProperty("System.Title", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemTitle { get; set; }

        [JsonProperty("Microsoft.Azure DevOps Services.Common.Severity", NullValueHandling = NullValueHandling.Ignore)]
        public required string Severity { get; set; }

        [JsonProperty("WEF_EB329F44FE5F4A94ACB1DA153FDF38BA_Kanban.Column", NullValueHandling = NullValueHandling.Ignore)]
        public required string KanbanColumn { get; set; }

        [JsonProperty("System.History", NullValueHandling = NullValueHandling.Ignore)]
        public required string SystemHistory { get; set; }
    }
}