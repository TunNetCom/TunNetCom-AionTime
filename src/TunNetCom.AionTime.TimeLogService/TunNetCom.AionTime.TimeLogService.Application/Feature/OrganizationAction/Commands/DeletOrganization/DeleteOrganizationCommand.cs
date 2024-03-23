namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;

public record DeleteOrganizationCommand(OrganizationRequest organization) : IRequest<int>;
