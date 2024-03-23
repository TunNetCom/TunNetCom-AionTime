using System;
namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Queries.GetOrganizationById
{
    public record GetOrganizationByIdQuery(int id):IRequest<OrganizationRequest>;
}
