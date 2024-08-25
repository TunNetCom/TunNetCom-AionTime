namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public class GetUserOrganizationRequest : BaseRequest
{
    public required string MemberId { get; set; }
}