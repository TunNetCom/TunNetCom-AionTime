using WorkItemRequest = AzureDevopsService.Contracts.AzureRequestResourceModel.WorkItemRequest;

namespace TimeLogService.Application.Events.IntegrationEvents.OutgoingEvents.WorkItem;

public record class WorkItemCommend(WorkItemRequest WorkItemRequest) : IRequest;