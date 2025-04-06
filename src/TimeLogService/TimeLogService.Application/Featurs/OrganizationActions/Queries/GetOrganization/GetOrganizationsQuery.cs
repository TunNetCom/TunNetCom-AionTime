using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganization;

namespace TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganization;

public record GetOrganizationsQuery()
    : IRequest<IReadOnlyList<OrganizationRequest>>;