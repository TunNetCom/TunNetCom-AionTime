namespace TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;

public record AddOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;