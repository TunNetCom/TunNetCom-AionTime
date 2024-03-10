namespace TunNetCom.AionTime.TimeLogService.Infrastructure.GenericRepository;

public class WorkItemTimeLogRepository:GeniricRepository<WorkItemTimeLog>, IWorkItemTimeLogRepository
{
    public WorkItemTimeLogRepository(TunNetComAionTimeTimeLogServiceDataBaseContext context):base(context)
    {
    }


    public async Task AddWorkItemTimeLog(List<WorkItemTimeLog> WorkItemTimeLogs)
    {
        await _context.AddRangeAsync(WorkItemTimeLogs);
        await _context.SaveChangesAsync();
    }

    public Task<WorkItemTimeLog> GetWorkItemTimeLogs(string userId, int leaveTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<WorkItemTimeLog> GetWorkItemTimeLogWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<WorkItemTimeLog>> GetWorkItemTimeLogWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<WorkItemTimeLog>> GetWorkItemTimeLogWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> WorkItemTimeLogExists(string userId, int leaveTypeId, int period)
    {
        throw new NotImplementedException();
    }
}
