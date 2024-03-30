namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands;
public record AddOrganizationCommand(OrganizationRequest organization) : IRequest<int>;