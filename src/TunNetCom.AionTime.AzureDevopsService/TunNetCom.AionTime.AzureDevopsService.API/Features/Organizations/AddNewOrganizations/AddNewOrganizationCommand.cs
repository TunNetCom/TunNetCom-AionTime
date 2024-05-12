namespace TunNetCom.AionTime.AzureDevopsService.API.Features.Organizations.AddNewOrganizations;

public record AddNewOrganizationCommand(string Name, string Pat) : IRequest<Result<string>>;