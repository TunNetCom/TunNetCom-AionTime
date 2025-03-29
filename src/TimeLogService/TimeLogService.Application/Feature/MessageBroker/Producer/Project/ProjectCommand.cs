using AzureDevopsService.Contracts.ExternalRequestModel;

namespace TimeLogService.Application.Feature.MessageBroker.Producer.Project;

public record class ProjectCommand(GetOrganizationProjectsRequest Request) : IRequest;