using AzureDevopsService.Contracts.ExternalRequestModel;

namespace TimeLogService.Application.Events.IntegrationEvents.OutgoingEvents.Project;

public record class ProjectCommand(GetOrganizationProjectsRequest Request) : IRequest;