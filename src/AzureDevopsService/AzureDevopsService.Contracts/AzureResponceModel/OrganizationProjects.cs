using System.Collections;

namespace AzureDevopsService.Contracts.AzureResponceModel;

public class OrganizationProjects
{
    [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
    public int Count { get; set; }

    [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<Project> Value { get; set; } = Enumerable.Empty<Project>();
}