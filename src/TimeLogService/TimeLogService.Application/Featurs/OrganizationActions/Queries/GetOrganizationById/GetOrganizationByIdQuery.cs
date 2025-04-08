namespace TimeLogService.Application.Featurs.OrganizationActions.Queries.GetOrganizationById;

public record GetOrganizationByIdQuery(int Id)
    : IRequest<OrganizationRequest>;