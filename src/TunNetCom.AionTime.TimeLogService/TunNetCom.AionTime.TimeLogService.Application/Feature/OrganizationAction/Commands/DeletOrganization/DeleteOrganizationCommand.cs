namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;

public record DeleteOrganizationCommand(int id) : IRequest<int>;
