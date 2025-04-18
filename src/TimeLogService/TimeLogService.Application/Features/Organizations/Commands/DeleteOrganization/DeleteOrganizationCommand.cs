namespace TimeLogService.Application.Features.Organizations.Commands.DeletOrganization;

public record DeleteOrganizationCommand(int Id)
    : IRequest<int>;