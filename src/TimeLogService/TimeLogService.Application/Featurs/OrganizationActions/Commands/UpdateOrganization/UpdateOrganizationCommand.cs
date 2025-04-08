namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;