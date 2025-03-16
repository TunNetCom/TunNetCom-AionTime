using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.InternalTreatement.AddTenant;

public record class AddTenantCommand(
    string OrganizationName,
    string OrganizationEmail,
    string OrganizationAdress,
    string OrganizationLandPhone,
    string OrganizationMobilePhone,
    string OrganizationDescription) : IRequest<OneOf<Guid, ProblemDetails>>;