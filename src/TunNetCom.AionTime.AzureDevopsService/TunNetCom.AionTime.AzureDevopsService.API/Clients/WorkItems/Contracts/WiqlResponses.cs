namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems.Contracts;

public class WiqlResponses
{
    public string QueryType { get; set; }

    public string QueryResultType { get; set; }

    public DateTime AsOf { get; set; }

    public List<Column> Columns { get; set; }

    public List<WorkItem> WorkItems { get; set; }
}