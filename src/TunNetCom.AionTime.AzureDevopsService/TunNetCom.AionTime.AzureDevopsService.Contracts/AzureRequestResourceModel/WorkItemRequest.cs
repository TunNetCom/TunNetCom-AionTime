using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel
{
    public class WorkItemRequest : BaseRequest
    {
        public required string OrganisationName { get; set; }

        public required string ProjectName { get; set; }
    }
}