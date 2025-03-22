namespace IdentityService.Application.Features.InternalTreatement.AddTenant;

public class AddTenantCommandHandler(AuthContext authContext, ILogger<AddTenantCommandHandler> logger)
    : IRequestHandler<AddTenantCommand, OneOf<Guid, ProblemDetails>>
{
    private readonly ILogger<AddTenantCommandHandler> _logger = logger;
    private readonly AuthContext _authContext = authContext;

    public async Task<OneOf<Guid, ProblemDetails>> Handle(AddTenantCommand request, CancellationToken cancellationToken)
    {
        Tenant? tenantExist = await _authContext.Tenants.FirstOrDefaultAsync(x => x.Email == request.Email);

        if (tenantExist is not null)
        {
            _logger.LogWarning($"Tenant {request.Name} already exist", request.Name);
            return new ProblemDetails()
            {
                Status = 400,
                Title = ErrorDetails.TenantOrganizationExist,
                Detail = ErrorDetails.TenantOrganizationExist,
            };
        }

        EntityEntry<Tenant> tenant = await _authContext.Tenants.AddAsync(new Tenant()
        {
            Name = request.Name,
            Address = request.Address,
            Description = request.Description,
            Email = request.Email,
            LandPhone = request.LandPhone,
            MobilePhone = request.MobilePhone,
        });

        _ = await _authContext.SaveChangesAsync();

        _logger.LogInformation($"Tenant {request.Name} created", request.Name);

        return tenant.Entity.Id;
    }
}