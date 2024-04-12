namespace TunNetCom.AionTime.TimeLogService.Application;

public record DeleteOrganizationCommand(int id) : IRequest<int>;
