using AzureDevopsService.Contracts.AzureRequestResourceModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

public class WiqlResponses : BaseRequest
{
    public string QueryType { get; set; } = string.Empty;

    public string QueryResultType { get; set; } = string.Empty;

    public DateTime AsOf { get; set; }

    public IEnumerable<Column> Columns { get; set; } = Enumerable.Empty<Column>();

    public IEnumerable<WorkItem> WorkItems { get; set; } = Enumerable.Empty<WorkItem>();
}