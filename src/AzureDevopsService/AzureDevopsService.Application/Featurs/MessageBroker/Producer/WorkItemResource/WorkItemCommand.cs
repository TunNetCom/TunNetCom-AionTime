namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.WorkItemResource;

public record class WorkItemCommand(WorkItemRequest WorkItemRequest) : IRequest;