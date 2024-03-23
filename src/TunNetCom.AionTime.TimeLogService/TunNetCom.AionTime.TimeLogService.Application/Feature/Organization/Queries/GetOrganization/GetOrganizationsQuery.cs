namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Queries.GetOrganization;

public record GetOrganizationsQuery():IRequest<IReadOnlyList<OrganizationRequest>>;
