using TunNetCom.AionTime.AzureDevopsService.API.Data;

namespace TunNetCom.AionTime.AzureDevopsService.API.Features.Organizations.AddNewOrganizations;

public partial class AddNewOrganizationHandler(
    AzureDevOpsContext azureDevOpsContext,
    ILogger<AddNewOrganizationHandler> logger)
    : IRequestHandler<AddNewOrganizationCommand, Result<string>>
{
    private readonly AzureDevOpsContext _azureDevOpsContext = azureDevOpsContext;
    private readonly ILogger<AddNewOrganizationHandler> _logger = logger;

    public async Task<Result<string>> Handle(
        AddNewOrganizationCommand request,
        CancellationToken cancellationToken)
    {
        Organization organization = new()
        {
            Name = request.Name,
            Pat = request.Pat,
        };

        bool isOrganizationExist = await _azureDevOpsContext
            .Organizations
            .AnyAsync(org => org.Name == organization.Name, cancellationToken);

        if (isOrganizationExist)
        {
            LogOrganizationExist(_logger, request.Name);
            return Result.Fail<string>("Organization already exist.");
        }

        _ = await _azureDevOpsContext.AddAsync(organization, cancellationToken);
        _ = await _azureDevOpsContext.SaveChangesAsync(cancellationToken);

        return organization.Name;
    }

    [LoggerMessage(
        EventId = 0,
        Level = LogLevel.Warning,
        Message = "Organization {OrganizationName} already exist.")]
    static partial void LogOrganizationExist(ILogger<AddNewOrganizationHandler> logger, string organizationName);
}