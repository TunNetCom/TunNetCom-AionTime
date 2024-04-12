namespace TunNetCom.AionTime.TimeLogService.Application;

public record GetOrganizationByIdQuery(int id):IRequest<OrganizationRequest>;
