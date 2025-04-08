namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.DeletOrganization;

public record DeleteOrganizationCommand(int Id)
    : IRequest<int>;