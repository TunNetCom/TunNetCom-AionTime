using AzureDevopsService.Contracts.AzureResponceModel;

namespace IdentityService.Application.Features.InternalTreatement.AddAzureInfo;

public record class AddAzureInfoCommand(UserProfile UserProfile) : IRequest;