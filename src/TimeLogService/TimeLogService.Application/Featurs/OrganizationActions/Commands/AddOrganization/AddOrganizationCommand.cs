using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganization;

namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganization;

public record AddOrganizationCommand(OrganizationRequest Organization)
    : IRequest<int>;