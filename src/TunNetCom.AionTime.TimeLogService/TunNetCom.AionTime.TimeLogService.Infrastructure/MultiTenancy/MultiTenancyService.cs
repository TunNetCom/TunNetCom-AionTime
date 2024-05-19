using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace TunNetCom.AionTime.TimeLogService.Infrastructure.MultiTenancy
{
    public sealed class MultiTenancyService(IHttpContextAccessor httpContextAccessor)
    {
        private const string TenantIdOrganization = "X-OrganizationId";
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public int GetTenantId()
        {
            Microsoft.Extensions.Primitives.StringValues? tenantIdHeader = _httpContextAccessor.HttpContext?
                .Request
                .Headers[TenantIdOrganization];

            if (!tenantIdHeader.HasValue ||
                !int.TryParse(tenantIdHeader.Value, out int tenantId))
            {
                return 0;
            }

            return tenantId;
        }
    }
}