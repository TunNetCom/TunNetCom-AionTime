using AzureDevopsWebhookService;
using AzureDevopsWebhookService.Contracts;
using AzureDevopsWebhookService.Contracts.EventModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels;
using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels
{
    public class Link
    {
        [JsonProperty("self", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? Self { get; set; }

        [JsonProperty("workItemUpdates", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? WorkItemRevisions { get; set; }

        [JsonProperty("workItemType", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? WorkItemType { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? Fields { get; set; }

        [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? Html { get; set; }

        [JsonProperty("workItemHistory", NullValueHandling = NullValueHandling.Ignore)]
        public Avatar? WorkItemHistory { get; set; }
    }
}