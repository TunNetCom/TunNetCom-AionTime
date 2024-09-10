namespace TimeLogService.Application.Feature.RabbitMqConsumer.Producer.Project;

public record class ProjectCommand(AllProjectUnderOrganizationRequest Request) : IRequest;