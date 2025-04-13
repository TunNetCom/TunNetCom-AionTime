using Newtonsoft.Json;

namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;

public class OrganizationProjectsResponce
{
    [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
    public int Count { get; set; }

    [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<ProjectResponce> Value { get; set; } = Enumerable.Empty<ProjectResponce>();
}