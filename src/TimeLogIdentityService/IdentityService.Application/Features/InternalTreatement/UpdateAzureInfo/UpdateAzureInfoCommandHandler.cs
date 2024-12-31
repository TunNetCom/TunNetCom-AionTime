using IdentityService.Application.Features.InternalTreatement.AddAzureInfo;
using IdentityService.Domain.Models.Dbo;
using IdentityService.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Application.Features.InternalTreatement.UpdateAzureInfo;

[SuppressMessage("Performance", "CA1823:Avoid unused private fields", Justification = "<Pending>")]
[SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification")]
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