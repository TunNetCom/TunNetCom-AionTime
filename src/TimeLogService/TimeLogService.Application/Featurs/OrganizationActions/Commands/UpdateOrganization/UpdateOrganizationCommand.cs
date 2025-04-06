using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.OrganizationActions.Commands.UpdateOrganization;

namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.UpdateOrganization;

public record UpdateOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;