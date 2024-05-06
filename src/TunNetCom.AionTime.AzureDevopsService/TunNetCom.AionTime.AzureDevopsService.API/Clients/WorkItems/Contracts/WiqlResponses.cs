namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems.Contracts;

public class WiqlResponses
{
    public string QueryType { get; set; } = string.Empty;

    public string QueryResultType { get; set; } = string.Empty;

    public DateTime AsOf { get; set; }

    public IEnumerable<Column> Columns { get; set; } = Enumerable.Empty<Column>();

    public IEnumerable<WorkItem> WorkItems { get; set; } = Enumerable.Empty<WorkItem>();
}