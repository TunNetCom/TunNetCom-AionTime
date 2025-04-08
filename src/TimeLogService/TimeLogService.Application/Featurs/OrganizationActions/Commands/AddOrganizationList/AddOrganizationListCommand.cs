namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganizationList;

public record class AddOrganizationListCommand(ReadOnlyCollection<Organization> Organizations) : IRequest;