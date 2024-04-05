namespace TunNetCom.AionTime.TimeLogService.Application;

public record GetOrganizationsQuery():IRequest<IReadOnlyList<OrganizationRequest>>;
