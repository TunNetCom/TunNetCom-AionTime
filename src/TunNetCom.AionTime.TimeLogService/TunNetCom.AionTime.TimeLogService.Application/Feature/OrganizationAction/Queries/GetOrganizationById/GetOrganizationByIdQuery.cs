namespace TunNetCom.AionTime.TimeLogService.Application;

public record GetOrganizationByIdQuery(int Id)
    : IRequest<OrganizationRequest>;
