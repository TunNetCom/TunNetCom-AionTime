namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;

public interface IOrganisationRepository
{
    Task AddOrganization(Organisation Organisation);
    Task<Organisation> GetOrganizationWithDetails(int id);
    Task<List<Organisation>> GetOrganizationsWithDetails();
    Task<bool> OrganizationExists(int Id);
    Task AddOrganizations(List<Organisation> organisations);
    Task<IReadOnlyList<Organisation>> GetOrganizations();
}
