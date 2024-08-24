using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Contracts;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel
{
    public class UserAccount : BaseRequest
    {
        [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }

        [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CA1002 // Do not expose generic lists
#pragma warning disable CA2227 // Collection properties should be read only
        public List<UserOrganization>? Value { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning restore CA1002 // Do not expose generic lists
    }
}