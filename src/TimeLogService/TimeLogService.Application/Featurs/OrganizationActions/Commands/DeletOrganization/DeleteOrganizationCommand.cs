using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.OrganizationActions.Commands.DeletOrganization;

namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.DeletOrganization;

public record DeleteOrganizationCommand(int Id)
    : IRequest<int>;