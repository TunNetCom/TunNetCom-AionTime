namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest organizationDTO) : IRequest<int>;