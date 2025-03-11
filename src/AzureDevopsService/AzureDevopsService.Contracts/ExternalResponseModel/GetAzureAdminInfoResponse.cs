namespace AzureDevopsService.Contracts.ExternalResponseModel;

public class GetAzureAdminInfoResponse : BaseRequest
{
    public required UserProfile UserProfile { get; set; }

    public UserAccountOrganization? UserOrganization { get; set; }
}