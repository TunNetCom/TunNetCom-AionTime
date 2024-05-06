namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganizationById;

public record GetOrganizationByIdQuery(int Id)
    : IRequest<OrganizationRequest>;