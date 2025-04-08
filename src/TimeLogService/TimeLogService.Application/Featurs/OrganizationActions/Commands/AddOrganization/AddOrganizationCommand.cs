namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganization;

public record AddOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;