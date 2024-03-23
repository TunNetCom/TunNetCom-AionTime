namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands;
public record AddOrganizationCommand(OrganizationRequest organizationDTO) : IRequest<int>;