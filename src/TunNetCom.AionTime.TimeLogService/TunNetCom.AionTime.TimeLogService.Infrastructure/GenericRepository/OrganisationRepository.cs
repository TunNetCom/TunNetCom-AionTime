namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class OrganisationRepository : GenericRepository<Organisation>, IOrganisationRepository
{
    public OrganisationRepository(TunNetComAionTimeTimeLogServiceDataBaseContext context) : base(context)
    {
    }

    public async Task AddOrganization(Organisation organization)
    {
        await AddAsync(organization);
    }

    public async Task AddOrganizations(List<Organisation> organizations)
    {
        await AddRangeAsync(organizations);
    }
    public async Task<IReadOnlyList<Organisation>> GetOrganizations()
    {
        return await GetAsync();
    }

    public Task<Organisation> GetOrganizationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Organisation>> GetOrganizationsWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<bool> OrganizationExists(int Id)
    {
        throw new NotImplementedException();
    }
}
