namespace TunNetCom.AionTime.TimeLogService.Application;

public record UpdateOrganizationCommand(OrganizationRequest organization) : IRequest<int>;