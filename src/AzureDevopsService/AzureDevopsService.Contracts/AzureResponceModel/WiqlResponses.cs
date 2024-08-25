namespace AzureDevopsService.Contracts.AzureResponceModel;

public class WiqlResponses : BaseRequest
{
    public string QueryType { get; set; } = string.Empty;

    public string QueryResultType { get; set; } = string.Empty;

    public DateTime AsOf { get; set; }

    public IEnumerable<Column> Columns { get; set; } = Enumerable.Empty<Column>();

    public IEnumerable<WorkItem> WorkItems { get; set; } = Enumerable.Empty<WorkItem>();
}