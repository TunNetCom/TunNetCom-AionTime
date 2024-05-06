namespace TunNetCom.AionTime.TimeLogService.Application;

public record AddOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;