using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganizationById;

namespace TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganizationById;

public record GetOrganizationByIdQuery(int Id)
    : IRequest<OrganizationRequest>;