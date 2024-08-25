namespace TimeLogService.Application.Feature.OrganizationAction.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;