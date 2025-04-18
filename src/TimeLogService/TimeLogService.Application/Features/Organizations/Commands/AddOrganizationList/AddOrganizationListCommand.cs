namespace TimeLogService.Application.Features.Organizations.Commands.AddOrganizationList;

public record class AddOrganizationListCommand(ReadOnlyCollection<Organization> Organizations) : IRequest;