namespace IdentityService.Application.Features.InternalTreatement.UpdateAzureInfo;

public record class UpdateAzureInfoCommand(string Email, string AzueKey) : IRequest;