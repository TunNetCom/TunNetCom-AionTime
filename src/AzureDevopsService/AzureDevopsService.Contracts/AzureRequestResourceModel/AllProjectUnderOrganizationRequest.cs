using AzureDevopsService.Contracts.AzureRequestResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel
{
    public class AllProjectUnderOrganizationRequest : BaseRequest
    {
        public required string OrganizationName { get; set; }
    }
}