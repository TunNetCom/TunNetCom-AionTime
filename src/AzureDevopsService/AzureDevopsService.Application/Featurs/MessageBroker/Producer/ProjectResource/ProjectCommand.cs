namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource;

public record class ProjectCommand(GetOrganizationProjectsRequest Request) : IRequest;