namespace TimeLogService.Application.Features.Organizations.Queries.GetOrganization;

public record GetOrganizationsQuery()
    : IRequest<IReadOnlyList<OrganizationRequest>>;