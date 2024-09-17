namespace AzureDevopsService.Contracts.AzureResponceModel;

public class UserAccount : BaseRequest
{
    [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
    public int Count { get; set; }

    [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<UserOrganization> Value { get; set; } = Enumerable.Empty<UserOrganization>();
}