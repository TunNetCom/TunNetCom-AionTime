namespace TunNetCom.AzureDevOps.TimeLogService.Application.Features.Organizations.Commands.CreateOrganization;

public class CreateOrganizationCommandHandler(
    IRepository<Organization> _repository,
    ILogger<CreateOrganizationCommandHandler> _logger)
    : IRequestHandler<CreateOrganizationCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Creating new organization. Name: {OrganizationName}, TenantId: {TenantId}",
            request.Name,
            request.TenantId);

        _logger.LogInformation(
            "Checking if organization with name {OrganizationName} already exists.",
            request.Name);

        bool isOrganisationExist = await _repository.IsPropertyExistAsync(
            x => x.Name,
            request.Name);

        if (isOrganisationExist)
        {
            _logger.LogWarning(
                "Organization with name {OrganizationName} already exists.",
                request.Name);
            return Result.Fail<int>("organization_exist");
        }

        var organization = Organization.Create(tenantId: request.TenantId, name: request.Name);

        int organizationId = await _repository.AddAsync(organization, cancellationToken);

        _logger.LogInformation(
            "Successfully created organization. OrganizationId: {OrganizationId}, Name: {OrganizationName}",
            organization.Id,
            organization.Name);

        return organizationId;
    }
}