using AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.ResourcesModels
{
    public class WorkItemResource
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [JsonProperty("rev", NullValueHandling = NullValueHandling.Ignore)]
        public string? Rev { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public Fileds? Fileds { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public Link? Links { get; set; }
    }
}