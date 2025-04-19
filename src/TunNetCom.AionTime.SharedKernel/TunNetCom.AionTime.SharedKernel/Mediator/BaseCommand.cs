using MediatR;

namespace TunNetCom.AionTime.SharedKernel.Mediator;

// Base interface for all tenant-aware commands
public interface ITenantCommand<TResponse> : IRequest<TResponse>
{
    Guid TenantId { get; }
}

// Non-generic version for commands without response
public interface ITenantCommand : IRequest
{
    Guid TenantId { get; }
}

// For commands with response
public abstract class TenantCommand<TResponse> : ITenantCommand<TResponse>
{
    public Guid TenantId { get; }

    protected TenantCommand(Guid tenantId)
    {
        TenantId = tenantId;
    }
}

// For commands without response
public abstract class TenantCommand : ITenantCommand
{
    public Guid TenantId { get; }

    protected TenantCommand(Guid tenantId)
    {
        TenantId = tenantId;
    }
}

public class TenantBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ICurrentTenantService _tenantService;

    public TenantBehavior(ICurrentTenantService tenantService)
    {
        _tenantService = tenantService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Set tenant from command if it's a tenant command
        if (request is ITenantCommand tenantCommand)
        {
            _tenantService.SetCurrentTenant(tenantCommand.TenantId);
        }

        return await next();
    }
}

public interface ICurrentTenantService
{
    Guid? CurrentTenantId { get; }
    void SetCurrentTenant(Guid tenantId);
}

public class CurrentTenantService : ICurrentTenantService
{
    public Guid? CurrentTenantId { get; private set; }

    public void SetCurrentTenant(Guid tenantId)
    {
        CurrentTenantId = tenantId;
    }
}

