using Microsoft.EntityFrameworkCore.ChangeTracking;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.InternalTreatement.AddTenant
{
    public class AddTenantCommandHandler(AuthContext authContext, ILogger<AddTenantCommandHandler> logger) : IRequestHandler<AddTenantCommand, OneOf<Guid, ProblemDetails>>
    {
        private readonly ILogger<AddTenantCommandHandler> _logger = logger;
        private readonly AuthContext _authContext = authContext;

        public async Task<OneOf<Guid, ProblemDetails>> Handle(AddTenantCommand request, CancellationToken cancellationToken)
        {
            Tenant? tenantExist = await _authContext.Tenants.FirstOrDefaultAsync(x => x.OrganizationEmail == request.OrganizationEmail);

            if (tenantExist != null)
            {
                return new ProblemDetails()
                {
                    Status = 400,
                    Title = "Organization already exist",
                    Detail = "Organization already exist",
                };
            }

            EntityEntry<Tenant> tenant = await _authContext.Tenants.AddAsync(new Tenant()
            {
                OrganizationName = request.OrganizationName,
                OrganizationAddress = request.OrganizationAdress,
                OrganizationDescription = request.OrganizationDescription,
                OrganizationEmail = request.OrganizationEmail,
                OrganizationLandPhone = request.OrganizationLandPhone,
                OrganizationMobilePhone = request.OrganizationMobilePhone,
            });

            _ = await _authContext.SaveChangesAsync();

            _logger.LogInformation("Tenant {TenantName} created", request.OrganizationName);

            return tenant.Entity.Id;
        }
    }
}