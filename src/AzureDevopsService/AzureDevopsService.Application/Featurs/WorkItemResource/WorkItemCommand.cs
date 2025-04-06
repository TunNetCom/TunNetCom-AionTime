namespace AzureDevopsService.Application.Featurs.WorkItemResource;

public record class WorkItemCommand(WorkItemRequest WorkItemRequest) : IRequest;