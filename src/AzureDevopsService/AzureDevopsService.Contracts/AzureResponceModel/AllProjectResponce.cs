using AzureDevopsService.Contracts.AzureRequestResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel
{
    public class AllProjectResponce : BaseRequest
    {
        [property: JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }

        [property: JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore)]
#pragma warning disable CA1002 // Do not expose generic lists
#pragma warning disable CA2227 // Collection properties should be read only
        public List<Project>? Value { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
#pragma warning restore CA1002 // Do not expose generic lists
    }
}