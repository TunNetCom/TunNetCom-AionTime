using WorkItemRequest = AzureDevopsService.Contracts.AzureRequestResourceModel.WorkItemRequest;

namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.WorkItem;

public record class WorkItemCommend(WorkItemRequest WorkItemRequest) : IRequest;