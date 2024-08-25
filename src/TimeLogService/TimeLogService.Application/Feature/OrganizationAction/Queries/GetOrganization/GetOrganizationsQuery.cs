namespace TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganization;

public record GetOrganizationsQuery()
    : IRequest<IReadOnlyList<OrganizationRequest>>;