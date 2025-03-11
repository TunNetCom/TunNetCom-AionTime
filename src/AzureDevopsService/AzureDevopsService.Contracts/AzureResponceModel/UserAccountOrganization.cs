namespace AzureDevopsService.Contracts.AzureResponceModel;

public class UserAccountOrganization
{
    [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
    public int Count { get; set; }

    [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<AzureOrganizationValue> Value { get; set; } = Enumerable.Empty<AzureOrganizationValue>();
}