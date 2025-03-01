using IdentityService.Application.Features.MessageBroker.Consumer;
using IdentityService.Domain.Models.Dbo;
using IdentityService.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IdentityService.Application.Features.InternalTreatement.AddAzureInfo;

public class AddAzureInfoCommandHandler(
    UserManager<ApplicationUser> userManager,
    AuthContext authContext,
    ILogger<AddAzureInfoCommandHandler> logger) : IRequestHandler<AddAzureInfoCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly AuthContext _authContext = authContext;
    private readonly ILogger<AddAzureInfoCommandHandler> _logger = logger;

    public async Task Handle(AddAzureInfoCommand request, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(request.UserProfile.EmailAddress);

        if (user == null)
        {
            _logger.LogError($"the user {request.UserProfile.Email} not found");
        }

        AzureInfo azureInfo = new()
        {
            IdentityUserId = user!.Id,
            EmailAddress = request.UserProfile.Email,
            PublicAlias = request.UserProfile.PublicAlias,
            PublicKey = request.UserProfile.Path,
            UserId = request.UserProfile.Id,
            Revision = request.UserProfile.Revision,
            PublicKeyExpirationDate = DateTime.Now,
            CoreRevision = request.UserProfile.CoreRevision,
            User = user,
            TimeStamp = request.UserProfile.TimeStamp,
        };

        _ = await _authContext.AzureInfo.AddAsync(azureInfo, cancellationToken);
        _ = await _authContext.SaveChangesAsync(cancellationToken);
    }
}