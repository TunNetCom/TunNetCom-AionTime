namespace TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;

public record DeleteOrganizationCommand(int Id)
    : IRequest<int>;