namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;

public interface IOrganisationRepository
{
    Task AddOrganisation(Organisation Organisation);
    Task<Organisation> GetOrganisationWithDetails(int id);
    Task<List<Organisation>> GetOrganisationsWithDetails();
    Task<bool> OrganisationExists(int Id);
    Task AddOrganisations(List<Organisation> organisations);
    Task<IReadOnlyList<Organisation>> GetOrganisations();
}
