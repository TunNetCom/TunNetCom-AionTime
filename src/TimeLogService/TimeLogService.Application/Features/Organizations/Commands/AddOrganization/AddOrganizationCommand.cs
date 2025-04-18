namespace TimeLogService.Application.Features.Organizations.Commands.AddOrganization;

public record AddOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;