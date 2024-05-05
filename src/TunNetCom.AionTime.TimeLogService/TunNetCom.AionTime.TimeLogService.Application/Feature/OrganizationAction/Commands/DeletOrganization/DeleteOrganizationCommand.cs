namespace TunNetCom.AionTime.TimeLogService.Application;

public record DeleteOrganizationCommand(int Id)
    : IRequest<int>;
