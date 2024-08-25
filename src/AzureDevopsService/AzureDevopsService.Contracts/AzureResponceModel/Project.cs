namespace AzureDevopsService.Contracts.AzureResponceModel
{
    public class Project
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public Uri? Url { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("revision")]
        public int Revision { get; set; }

        [JsonProperty("visibility")]
        public string? Visibility { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }
    }
}