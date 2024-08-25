using AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace AzureDevopsService.Contracts.AzureRequestResourceModel
{
    public class WiqlRequest : BaseRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; } = string.Empty;

        [JsonProperty("organization")]
        public string Organization { get; set; } = string.Empty;

        [JsonProperty("project")]
        public string Project { get; set; } = string.Empty;

        [JsonProperty("team")]
        public string Team { get; set; } = string.Empty;

        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; } = string.Empty;
    }
}