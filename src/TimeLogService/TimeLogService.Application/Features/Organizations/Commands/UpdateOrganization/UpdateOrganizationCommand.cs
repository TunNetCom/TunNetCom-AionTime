namespace TimeLogService.Application.Features.Organizations.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;