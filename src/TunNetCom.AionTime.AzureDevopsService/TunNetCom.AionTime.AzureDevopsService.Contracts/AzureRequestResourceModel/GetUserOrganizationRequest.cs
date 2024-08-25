using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel
{
    public class GetUserOrganizationRequest : BaseRequest
    {
        public required string MemberId { get; set; }
    }
}