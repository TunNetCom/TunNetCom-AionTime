namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class OrganisationRepository : GeniricRepository<Organisation>, IOrganisationRepository
{
    public OrganisationRepository(TunNetComAionTimeTimeLogServiceDataBaseContext context) : base(context)
    {
    }

    public async Task AddOrganisation(Organisation Organisation)
    {
        await AddAsync(Organisation);
    }

    public async Task AddOrganisations(List<Organisation> organisations)
    {
        await AddRangeAsync(organisations);
    }
    public async Task<IReadOnlyList<Organisation>> GetOrganisations()
    {
        return await GetAsync();
    }

    public Task<Organisation> GetOrganisationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Organisation>> GetOrganisationsWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<bool> OrganisationExists(int Id)
    {
        throw new NotImplementedException();
    }
}
