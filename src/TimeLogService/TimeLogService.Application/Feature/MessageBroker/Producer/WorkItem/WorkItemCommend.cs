using WorkItemRequest = AzureDevopsService.Contracts.AzureRequestResourceModel.WorkItemRequest;

namespace TimeLogService.Application.Feature.MessageBroker.Producer.WorkItem;

public record class WorkItemCommend(WorkItemRequest WorkItemRequest) : IRequest;