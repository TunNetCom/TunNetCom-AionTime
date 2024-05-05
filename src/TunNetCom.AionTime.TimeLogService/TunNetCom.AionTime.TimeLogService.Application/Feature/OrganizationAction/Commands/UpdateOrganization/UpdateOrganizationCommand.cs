namespace TunNetCom.AionTime.TimeLogService.Application;

public record UpdateOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;