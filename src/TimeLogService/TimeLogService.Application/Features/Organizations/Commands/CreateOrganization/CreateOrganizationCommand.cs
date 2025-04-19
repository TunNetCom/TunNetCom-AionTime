using TunNetCom.AionTime.SharedKernel.Mediator;

namespace TunNetCom.AzureDevOps.TimeLogService.Application.Features.Organizations.Commands.CreateOrganization;

public class CreateOrganizationCommand : TenantCommand<Result<int>>
{
    public CreateOrganizationCommand(Guid tenantId, string name) : base(tenantId)
    {
        Name = name;
    }

    public string Name { get; }
}
