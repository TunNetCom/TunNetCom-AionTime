namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest organizationDTO) : IRequest<int>;