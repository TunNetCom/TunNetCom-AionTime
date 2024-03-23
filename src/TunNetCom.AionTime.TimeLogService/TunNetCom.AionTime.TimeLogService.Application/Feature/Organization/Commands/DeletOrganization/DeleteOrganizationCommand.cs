namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.DeletOrganization;

public record DeleteOrganizationCommand(OrganizationRequest organization) : IRequest<int>;
