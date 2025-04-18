namespace TimeLogService.Application.Features.Organizations.Queries.GetOrganizationById;

public record GetOrganizationByIdQuery(int Id)
    : IRequest<OrganizationRequest>;