using System.Security.Principal;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Committer
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
    public string? Email { get; set; }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime Date { get; set; }
}