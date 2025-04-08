namespace TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganization;

public record GetOrganizationsQuery()
    : IRequest<IReadOnlyList<OrganizationRequest>>;