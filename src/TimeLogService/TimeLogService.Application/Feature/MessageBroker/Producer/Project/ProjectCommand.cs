namespace TimeLogService.Application.Feature.MessageBroker.Producer.Project;

public record class ProjectCommand(AllProjectUnderOrganizationRequest Request) : IRequest;