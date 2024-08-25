namespace AzureDevopsService.Contracts.AzureRequestResourceModel
{
    public class AllProjectUnderOrganizationRequest : BaseRequest
    {
        public required string OrganizationName { get; set; }
    }
}