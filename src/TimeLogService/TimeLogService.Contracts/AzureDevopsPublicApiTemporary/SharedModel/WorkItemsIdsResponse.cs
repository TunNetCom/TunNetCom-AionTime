using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.SharedModel
{
    public class WorkItemsIdsResponse
    {
        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        [JsonProperty("queryResultType")]
        public string QueryResultType { get; set; }

        [JsonProperty("asOf")]
        public DateTime AsOf { get; set; }

        [JsonProperty("columns")]
        public List<Column> Columns { get; set; }

        [JsonProperty("workItems")]
        public List<WorkItem> WorkItems { get; set; }
    }

    public class Column
    {
        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class WorkItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
