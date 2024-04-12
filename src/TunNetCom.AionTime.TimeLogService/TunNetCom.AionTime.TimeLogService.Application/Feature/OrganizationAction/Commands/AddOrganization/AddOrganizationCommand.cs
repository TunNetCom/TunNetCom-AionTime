namespace TunNetCom.AionTime.TimeLogService.Application;
public record AddOrganizationCommand(OrganizationRequest organization) : IRequest<int>;