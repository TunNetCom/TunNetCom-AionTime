using IdentityService.Application.Features.InternalTreatement.AddAzureInfo;
using IdentityService.Domain.Models.Dbo;
using IdentityService.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.InternalTreatement.UpdateAzureInfo;

public class UpdateAzureInfoCommandHandler(
    UserManager<ApplicationUser> userManager,
    AuthContext authContext,
    ILogger<UpdateAzureInfoCommandHandler> logger) : IRequestHandler<UpdateAzureInfoCommand>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly AuthContext _authContext = authContext;
    private readonly ILogger<UpdateAzureInfoCommandHandler> _logger = logger;

    public Task Handle(UpdateAzureInfoCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}